using Ambev.DeveloperEvaluation.Application.Sale.UpdateSaleItem;
using Ambev.DeveloperEvaluation.Domain.Client;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

public class UpdateSaleItemHandlerTests
{
    private readonly IMapper _mapper;
    private readonly ISaleRepository _saleRepository;
    private readonly IRabbitMQClient _rabbitMqClient;
    private readonly UpdateSaleItemHandler _handler;

    public UpdateSaleItemHandlerTests()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _mapper = Substitute.For<IMapper>();
        _rabbitMqClient = Substitute.For<IRabbitMQClient>();
        _handler = new UpdateSaleItemHandler(_saleRepository, _mapper, _rabbitMqClient);
    }

    [Fact(DisplayName = "Given valid command When updating sale item Then item is updated and event is published")]
    public async Task Handle_ValidCommand_UpdatesItemAndPublishesEvents()
    {
        // Given
        var command = UpdateSaleItemHandlerTestData.GenerateValidCommand();
        var existingItem = UpdateSaleItemHandlerTestData.GenerateMockSaleItem(command.Id);

        _saleRepository.GetItemByIdAsync(command.Id, Arg.Any<CancellationToken>())
            .Returns(existingItem);

        // Em vez de mapear para um novo item, mapeia diretamente para o existente
        _mapper.Map(command, existingItem).Returns(existingItem);

        var saleItemResult = new UpdateSaleItemResult
        {
            Id = existingItem.Id,
            SaleId = existingItem.SaleId,
            Product = existingItem.Product,
            Quantity = command.Quantity,
            UnitPrice = command.UnitPrice,
            IsCancelled = existingItem.IsCancelled, // Ajuste conforme a lógica de negócio
        };
        _mapper.Map<UpdateSaleItemResult>(existingItem).Returns(saleItemResult);

        // When
        var result = await _handler.Handle(command, CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(saleItemResult);
        await _saleRepository.Received(1).UpdateItemAsync(existingItem, Arg.Any<CancellationToken>());
        await _rabbitMqClient.Received(1).BasicTestPublish("SaleItemUpdated", $"Sale item updated with success. Id: {existingItem.Id}");
    }

    [Fact(DisplayName = "Given cancelled sale item When updating Then throws InvalidOperationException")]
    public async Task Handle_CancelledItem_ThrowsInvalidOperationException()
    {
        // Given
        var command = UpdateSaleItemHandlerTestData.GenerateValidCommand();
        var cancelledItem = UpdateSaleItemHandlerTestData.GenerateMockSaleItem(command.Id, isCancelled: true);

        _saleRepository.GetItemByIdAsync(command.Id, Arg.Any<CancellationToken>())
            .Returns(cancelledItem);

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("Its not possible to update a cancelled sale item");
    }
}