using Ambev.DeveloperEvaluation.Domain.Client;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.DeleteSale;

/// <summary>
///     Handler for processing DeleteSaleCommand requests
/// </summary>
public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, bool>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IRabbitMQClient _rabbitMqClient;

    /// <summary>
    ///     Initializes a new instance of DeleteSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="rabbitMqClient">rabbit mq client, to publish messages in message broker instance</param>
    public DeleteSaleHandler(ISaleRepository saleRepository, IRabbitMQClient rabbitMqClient)
    {
        _saleRepository = saleRepository;
        _rabbitMqClient = rabbitMqClient;
    }

    /// <summary>
    ///     Handles the DeleteSaleCommand request
    /// </summary>
    /// <param name="command">The DeleteSale command providing Sale Id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True when object was successfully deleted or false when object not found.</returns>
    public async Task<bool> Handle(DeleteSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new DeleteSaleCommandValidator();

        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);
        
        await _rabbitMqClient.BasicTestPublish("SaleDeleted", $"Sale deleted with success. Id: {command.Id}");
        
        return await _saleRepository.DeleteAsync(command.Id, cancellationToken);
    }
}