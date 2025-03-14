﻿using Ambev.DeveloperEvaluation.Application.Sale.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
/// Contains unit tests for the <see cref="CreateSaleItemHandler"/> class.
/// </summary>
public class CreateSaleItemHandlerTests
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly CreateSaleItemHandler _handler;

    /// <summary>
    /// Initializes a new instance of <see cref="CreateSaleItemHandlerTests"/> class.
    /// Sets up test dependencies.
    /// </summary>
    public CreateSaleItemHandlerTests()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _mapper = Substitute.For<IMapper>();
        _handler = new CreateSaleItemHandler(_saleRepository, _mapper);
    }

    /// <summary>
    /// Tests that adding a valid sale item succeeds.
    /// </summary>
    [Fact(DisplayName = "Given valid sale item When added to sale Then returns success")]
    public async Task Handle_ValidRequest_AddsSaleItem()
    {
        // Given
        var command = CreateSaleItemHandlerTestData.GenerateValidCommand();
        var existingSale = CreateSaleItemHandlerTestData.GenerateMockSale();

        _saleRepository.GetByIdAsync(command.SaleId, Arg.Any<CancellationToken>())
            .Returns(existingSale);

        var expectedSaleItem = new SaleItem
        {
            Product = command.Product,
            Quantity = command.Quantity,
            UnitPrice = command.UnitPrice,
            Discount = command.Discount
        };

        _mapper.Map<SaleItem>(command).Returns(expectedSaleItem);

        var expectedResult = new CreateSaleItemResult
        {
            Id = Guid.NewGuid()
        };

        _mapper.Map<CreateSaleItemResult>(expectedSaleItem).Returns(expectedResult);

        // When
        var result = await _handler.Handle(command, CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(expectedResult);
        await _saleRepository.Received(1).UpdateAsync(existingSale, Arg.Any<CancellationToken>());
    }

    /// <summary>
    /// Tests that adding a sale item to a non-existing sale throws exception.
    /// </summary>
    [Fact(DisplayName = "Given non-existing sale id When adding sale item Then throws InvalidOperationException")]
    public async Task Handle_NonExistingSaleId_ThrowsInvalidOperationException()
    {
        // Given
        var command = CreateSaleItemHandlerTestData.GenerateValidCommand();

        _saleRepository.GetByIdAsync(command.SaleId, Arg.Any<CancellationToken>())
            .Returns((Sale)null);

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage($"Sale with ID {command.SaleId} not found");
    }
}