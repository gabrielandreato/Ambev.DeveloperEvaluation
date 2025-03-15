using Ambev.DeveloperEvaluation.Domain.Client;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.UpdateSaleItem;

/// <summary>
///     Handler for processing UpdateSaleItemCommand requests
/// </summary>
public class UpdateSaleItemHandler : IRequestHandler<UpdateSaleItemCommand, UpdateSaleItemResult>
{
    private readonly IMapper _mapper;
    private readonly IRabbitMQClient _rabbitMqClient;
    private readonly ISaleRepository _saleRepository;

    /// <summary>
    ///     Initializes a new instance of UpdateSaleItemHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for UpdateSaleItemCommand</param>
    /// <param name="rabbitMqClient">rabbit mq client, to publish messages in message broker instance</param>
    public UpdateSaleItemHandler(ISaleRepository saleRepository, IMapper mapper, IRabbitMQClient rabbitMqClient)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _rabbitMqClient = rabbitMqClient;
    }

    /// <summary>
    ///     Handles the UpdateSaleItemCommand request
    /// </summary>
    /// <param name="command">The UpdateSaleItem command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated sale details</returns>
    public async Task<UpdateSaleItemResult> Handle(UpdateSaleItemCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateSaleItemCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        var existent = await _saleRepository.GetItemByIdAsync(command.Id, cancellationToken);

        ValidateAsync(command, existent);

        _mapper.Map(command, existent);

        InicializeData(existent!);

        await _saleRepository.UpdateItemAsync(existent!, cancellationToken);

        await NotifyEventsAsync(existent!);

        var result = _mapper.Map<UpdateSaleItemResult>(existent);

        return result;
    }

    private static void InicializeData(SaleItem saleItem)
    {
        saleItem.CalculateDiscount();
        saleItem.IsGreaterThan20();
    }

    private static void ValidateAsync(UpdateSaleItemCommand command, SaleItem? item)
    {
        if (item == null) throw new InvalidOperationException($"Sale with ID {command.Id} not found");

        if (item.IsCancelled)
            throw new InvalidOperationException("Its not possible to update a cancelled sale item");
    }

    private async Task NotifyEventsAsync(SaleItem saleItem)
    {
        if (saleItem.IsCancelled)
            await _rabbitMqClient.BasicTestPublish("SaleItemCancelled",
                $"Sale item cancelled with success. Id: {saleItem.Id}");

        await _rabbitMqClient.BasicTestPublish("SaleItemUpdated", $"Sale item updated with success. Id: {saleItem.Id}");
    }
}