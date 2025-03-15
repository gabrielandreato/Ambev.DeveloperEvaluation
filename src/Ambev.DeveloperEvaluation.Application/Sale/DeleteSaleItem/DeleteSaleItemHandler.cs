using Ambev.DeveloperEvaluation.Domain.Client;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.DeleteSaleItem;

/// <summary>
///     Handler for processing DeleteSaleItemCommand requests
/// </summary>
public class DeleteSaleItemHandler : IRequestHandler<DeleteSaleItemCommand, bool>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IRabbitMQClient _rabbitMqClient;

    /// <summary>
    ///     Initializes a new instance of DeleteSaleItemHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="rabbitMqClient">rabbit mq client, to publish messages in message broker instance</param>
    public DeleteSaleItemHandler(ISaleRepository saleRepository, IRabbitMQClient rabbitMqClient)
    {
        _saleRepository = saleRepository;
        _rabbitMqClient = rabbitMqClient;
    }

    /// <summary>
    ///     Handles the DeleteSaleItemCommand request
    /// </summary>
    /// <param name="command">The DeleteSaleItem command providing SaleItem Id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True when object was successfully deleted or false when object not found.</returns>
    public async Task<bool> Handle(DeleteSaleItemCommand command, CancellationToken cancellationToken)
    {
        var validator = new DeleteSaleItemCommandValidator();

        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        var deleteItemAsync = await _saleRepository.DeleteItemAsync(command.Id, cancellationToken);
        
        await _rabbitMqClient.BasicTestPublish("SaleItemDeleted", $"Sale item deleted with success. Id: {command.Id}");

        return deleteItemAsync;
    }
}