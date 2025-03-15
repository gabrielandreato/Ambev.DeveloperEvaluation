using System.Text;
using Ambev.DeveloperEvaluation.Domain.Client;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using Serilog;

namespace Ambev.DeveloperEvaluation.MessageBroker.RabbitMqClient;

/// <summary>
/// Rabbit mq client, used to connect and publish messages.
/// </summary>
public class RabbitMqClient : IRabbitMQClient
{
    private IModel _channel = null!;
    private IConfiguration _configuration;

    /// <summary>
    /// Constructor to instanciate RabbitMqClient
    /// </summary>
    /// <param name="configuration">instance of configuration, to get configurations in app settings from web api layer.</param>
    public RabbitMqClient(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// set a connection with rabbit mq
    /// </summary>
    /// <param name="hostname">host name for server where rabbit is hosted</param>
    /// <param name="username">user name to connect in the rabbit</param>
    /// <param name="password">password to connect in the rabbit</param>
    private void ConnectToRabbit(string hostname, string username, string password)
    {
        var connection = new ConnectionFactory();
        connection.HostName = hostname;
        connection.UserName = username;
        connection.Password = password;
        connection.Ssl.ServerName = hostname;
        connection.Ssl.Enabled = false;
        var cf = connection.CreateConnection();
        _channel = cf.CreateModel();
    }

    /// <inheritdoc />
    public Task BasicPublish(string queueName, string message)
    {
        var hostname = _configuration["RabbitMq:hostname"] ?? throw new Exception("Hostname cannot be null.");
        var username = _configuration["RabbitMq:username"] ?? throw new Exception("UserName cannot be null.");
        var password = _configuration["RabbitMq:password"] ?? throw new Exception("Password cannot be null.");

        ConnectToRabbit(hostname, username, password);
        var body = Encoding.UTF8.GetBytes(message);
        _channel.ExchangeDeclare(queueName, ExchangeType.Fanout);
        _channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false);
        _channel.QueueBind(queue: queueName, exchange: queueName, routingKey: queueName);
        _channel.BasicPublish(queueName, queueName, null, body);
        return Task.CompletedTask;
    }


    /// <inheritdoc />
    public async Task BasicTestPublish(string queueName, string message)
    {
        Log.Information("Sended message: {Message}; to queue {QueueName}", message, queueName);
    }
}