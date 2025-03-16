namespace Ambev.DeveloperEvaluation.Domain.Client;

public interface IRabbitMQClient
{
    /// <summary>
    ///     Publish a message in Rabbit MQ
    /// </summary>
    /// <param name="queueName">Queue name to publish message</param>
    /// <param name="message">message string to be published, it could be a serialized json as well.</param>
    /// <returns></returns>
    Task BasicPublish(string queueName, string message);

    Task BasicTestPublish(string queueName, string message);
}