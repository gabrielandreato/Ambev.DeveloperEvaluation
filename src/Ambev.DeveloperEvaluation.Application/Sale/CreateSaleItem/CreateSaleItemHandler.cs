using Ambev.DeveloperEvaluation.Domain.Client;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSaleItem;

/// <summary>
///     Handler for processing CreateSaleItemCommand requests
/// </summary>
public class CreateSaleItemHandler : IRequestHandler<CreateSaleItemCommand, CreateSaleItemResult>
{
    private readonly IMapper _mapper;
    private readonly ISaleRepository _saleRepository;
    private readonly IRabbitMQClient _rabbitMqClient;

    /// <summary>
    ///     Initializes a new instance of CreateSaleItemHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateSaleItemCommand</param>
    /// <param name="rabbitMqClient">rabbit mq client, to publish messages in message broker instance</param>
    public CreateSaleItemHandler(ISaleRepository saleRepository, IMapper mapper, IRabbitMQClient rabbitMqClient)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _rabbitMqClient = rabbitMqClient;
    }

    /// <summary>
    ///     Handles the CreateSaleItemCommand request
    /// </summary>
    /// <param name="command">The CreateSaleItem command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale details</returns>
    public async Task<CreateSaleItemResult> Handle(CreateSaleItemCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleItemCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        var sale = await _saleRepository.GetByIdAsync(command.SaleId, cancellationToken);

        if (sale == null)
            throw new InvalidOperationException($"Sale with ID {command.SaleId} not found");

        var saleItem = _mapper.Map<SaleItem>(command);
        sale.Items.Add(saleItem);

        await _saleRepository.UpdateAsync(sale, cancellationToken);
        
        await _rabbitMqClient.BasicTestPublish("SaleItemCreated", $"Sale item created with success. Id: {saleItem.Id}");

        var result = _mapper.Map<CreateSaleItemResult>(saleItem);

        return result;
    }
}