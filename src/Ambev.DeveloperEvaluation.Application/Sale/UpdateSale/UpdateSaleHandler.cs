using Ambev.DeveloperEvaluation.Domain.Client;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.UpdateSale;

/// <summary>
///     Handler for processing UpdateSaleCommand requests
/// </summary>
public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly IMapper _mapper;
    private readonly IRabbitMQClient _rabbitMQClient;
    private readonly ISaleRepository _saleRepository;

    /// <summary>
    ///     Initializes a new instance of UpdateSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for UpdateSaleCommand</param>
    /// <param name="rabbitMqClient">rabbit mq client, to publish messages in message broker instance</param>
    public UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper, IRabbitMQClient rabbitMqClient)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _rabbitMQClient = rabbitMqClient;

    }

    /// <summary>
    ///     Handles the UpdateSaleCommand request
    /// </summary>
    /// <param name="command">The UpdateSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Updated sale details</returns>
    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        var existentSale = await _saleRepository.GetByIdAsync(command.Id, cancellationToken);

        await ValidateAsync(command, cancellationToken, existentSale);

        _mapper.Map(command, existentSale);

        await _saleRepository.UpdateAsync(existentSale!, cancellationToken);

        var result = _mapper.Map<UpdateSaleResult>(existentSale);

        await NotifyEventsAsync(command);

        return result;
    }

    private async Task ValidateAsync(UpdateSaleCommand command, CancellationToken cancellationToken,
        Domain.Entities.Sale? existentSale)
    {

        if (existentSale == null)
            throw new InvalidOperationException($"Sale with identifier {command.Id} not found");

        if (existentSale.IsCancelled)
            throw new InvalidOperationException("Its not possible to update a cancelled sale");

        var researchBySaleNumber = await _saleRepository.GetBySaleNumberAsync(command.SaleNumber, cancellationToken);
        if (researchBySaleNumber != null &&  researchBySaleNumber.Id != command.Id)
            throw new InvalidOperationException($"Sale with number {command.SaleNumber} already exists");
    }

    private async Task NotifyEventsAsync(UpdateSaleCommand command)
    {
        await _rabbitMQClient.BasicTestPublish("SaleUpdated", $"A sale was updated. Id {command.Id}");
        if (command.IsCancelled)
            await _rabbitMQClient.BasicTestPublish("SaleCancelled", $"A sale was cancelled. Id {command.Id}");
    }
}