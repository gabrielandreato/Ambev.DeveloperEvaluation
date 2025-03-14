using Ambev.DeveloperEvaluation.Application.Sale.GetListSale;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class GetListSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly GetListSaleHandler _handler;

        public GetListSaleHandlerTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new GetListSaleHandler(_saleRepository, _mapper);
        }

        [Fact(DisplayName = "When getting sales list without filters Then returns all sales")]
        public async Task Handle_WithoutFilters_ShouldReturnAllSales()
        {
            // Given
            var command = new GetListSaleCommand();
            var salesList = GetListSaleHandlerTestData.GenerateMockSales();

            _saleRepository.GetListAsync(
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    Arg.Any<CancellationToken>())
                .Returns(salesList);

            var expectedResult = new List<GetListSaleResult>();
            foreach (var sale in salesList)
            {
                expectedResult.Add(new GetListSaleResult
                {
                    SaleNumber = sale.SaleNumber,
                    SaleDate = sale.SaleDate,
                    Customer = sale.Customer,
                    Branch = sale.Branch,
                    // Preencha outros mapeamentos conforme a estrutura de GetListSaleResult
                });
            }

            _mapper.Map<List<GetListSaleResult>>(salesList).Returns(expectedResult);

            // When
            var result = await _handler.Handle(command, CancellationToken.None);

            // Then
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(salesList.Count);
            await _saleRepository.Received(1).GetListAsync(
                null, null, null, null, null, null, Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "When getting sales list with filters Then returns filtered sales")]
        public async Task Handle_WithFilters_ShouldReturnFilteredSales()
        {
            // Given
            var command = new GetListSaleCommand
            {
                SaleNumber = "12345",
                IsCanceled = false,
                Branch = Branch.BranchA,
                Customer = Customer.CustomerA,
                SaleDateFrom = DateTime.Now.AddDays(-30),
                SaleDateTo = DateTime.Now
            };

            var filteredSales = GetListSaleHandlerTestData.GenerateFilteredMockSales();

            _saleRepository.GetListAsync(
                    command.SaleNumber,
                    command.IsCanceled,
                    command.Branch,
                    command.Customer,
                    command.SaleDateFrom,
                    command.SaleDateTo,
                    Arg.Any<CancellationToken>())
                .Returns(filteredSales);

            // Cria o resultado esperado mapeando manualmente os itens
            var expectedResult = new List<GetListSaleResult>();
            foreach (var sale in filteredSales)
            {
                expectedResult.Add(new GetListSaleResult
                {
                    SaleNumber = sale.SaleNumber,
                    SaleDate = sale.SaleDate,
                    Customer = sale.Customer,
                    Branch = sale.Branch,
                    // Preencha outros mapeamentos conforme a estrutura de GetListSaleResult
                });
            }

            // Configura o mock do mapper para retornar o resultado esperado
            _mapper.Map<List<GetListSaleResult>>(filteredSales).Returns(expectedResult);

            // When
            var result = await _handler.Handle(command, CancellationToken.None);

            // Then
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(filteredSales.Count);
            await _saleRepository.Received(1).GetListAsync(
                command.SaleNumber,
                command.IsCanceled,
                command.Branch,
                command.Customer,
                command.SaleDateFrom,
                command.SaleDateTo,
                Arg.Any<CancellationToken>());
        }
    }
}