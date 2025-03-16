using Ambev.DeveloperEvaluation.Application.Sale.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Client;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
///     Contains unit tests for the <see cref="CreateSaleHandler" /> class.
/// </summary>
public class CreateSaleHandlerTests
{
    private readonly CreateSaleHandler _handler;
    private readonly IMapper _mapper;
    private readonly IRabbitMQClient _rabbitMQClient;
    private readonly ISaleRepository _saleRepository;

    /// <summary>
    ///     Initializes a new instance of the <see cref="CreateSaleHandlerTests" /> class.
    ///     Sets up the test dependencies and creates fake data generators.
    /// </summary>
    public CreateSaleHandlerTests()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _mapper = Substitute.For<IMapper>();
        _rabbitMQClient = Substitute.For<IRabbitMQClient>();
        _handler = new CreateSaleHandler(_saleRepository, _mapper, _rabbitMQClient);
    }

    /// <summary>
    ///     Tests that a valid sale creation request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid sale data When creating sale Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand();

        var saleId = Guid.NewGuid();
        var saleItems = command.Items.Select(item => new SaleItem(
            saleId,
            item.Product,
            item.Quantity,
            item.UnitPrice)
        ).ToList();

        var sale = new Sale
        {
            Id = saleId,
            SaleNumber = command.SaleNumber,
            SaleDate = command.SaleDate,
            Items = saleItems
        };

        var result = new CreateSaleResult
        {
            Id = sale.Id
        };

        _mapper.Map<Sale>(command).Returns(sale);
        _mapper.Map<CreateSaleResult>(sale).Returns(result);

        _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
            .Returns(sale);

        // When
        var createSaleResult = await _handler.Handle(command, CancellationToken.None);

        // Then
        createSaleResult.Should().NotBeNull();
        createSaleResult.Id.Should().Be(sale.Id);
        await _saleRepository.Received(1).CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }

    /// <summary>
    ///     Tests that an invalid sale creation request throws a validation exception.
    /// </summary>
    [Fact(DisplayName = "Given invalid sale data When creating sale Then throws validation exception")]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        // Given
        var command = new CreateSaleCommand();

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<ValidationException>();
    }

    /// <summary>
    ///     Tests that the mapper is called with the correct command.
    /// </summary>
    [Fact(DisplayName = "Given valid command When handling Then maps command to sale entity")]
    public async Task Handle_ValidRequest_MapsCommandToSale()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand();

        var saleId = Guid.NewGuid();
        var saleItems = command.Items.Select(item => new SaleItem(
            saleId,
            item.Product,
            item.Quantity,
            item.UnitPrice)
        ).ToList();

        var sale = new Sale
        {
            Id = saleId,
            SaleNumber = command.SaleNumber,
            SaleDate = command.SaleDate,
            Items = saleItems
        };

        _mapper.Map<Sale>(command).Returns(sale);
        _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
            .Returns(sale);

        var saleResult = new CreateSaleResult
        {
            Id = saleId
        };
        _mapper.Map<CreateSaleResult>(sale).Returns(saleResult);

        // When
        await _handler.Handle(command, CancellationToken.None);

        // Then
        _mapper.Received(1)
            .Map<Sale>(Arg.Is<CreateSaleCommand>(c =>
                c.SaleDate == command.SaleDate
                && c.SaleNumber == command.SaleNumber
                && c.Customer == command.Customer
                && c.Branch == command.Branch
                && c.Items == command.Items));
    }

    /// <summary>
    ///     Tests that creating a sale with an existing sale number throws an InvalidOperationException.
    /// </summary>
    [Fact(DisplayName = "Given existing sale number When creating sale Then throws InvalidOperationException")]
    public async Task Handle_ExistingSaleNumber_ThrowsInvalidOperationException()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand();

        var saleId = Guid.NewGuid();
        var saleItems = command.Items.Select(item => new SaleItem(
            saleId,
            item.Product,
            item.Quantity,
            item.UnitPrice)
        ).ToList();

        var existingSale = new Sale
        {
            Id = saleId,
            SaleNumber = command.SaleNumber,
            SaleDate = command.SaleDate,
            Items = saleItems
        };

        _mapper.Map<Sale>(command).Returns(existingSale);

        _saleRepository.GetBySaleNumberAsync(command.SaleNumber, CancellationToken.None)
            .Returns(existingSale);

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage($"Sale with number {command.SaleNumber} already exists");
    }
}