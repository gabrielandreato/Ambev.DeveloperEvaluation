using Ambev.DeveloperEvaluation.Application.Sale.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData;

/// <summary>
///     Provides methods for generating test data using the Bogus library.
///     This class centralizes all test data generation to ensure consistency
///     across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class GetSaleHandlerTestData
{
    /// <summary>
    ///     Configures the Faker to generate valid Sale entities.
    /// </summary>
    private static readonly Faker<GetSaleCommand> getSaleCommandFaker = new Faker<GetSaleCommand>()
        .RuleFor(c => c.Id, f => f.Random.Guid());

    /// <summary>
    ///     Generates a valid GetSaleCommand with randomized data.
    /// </summary>
    /// <returns>A valid GetSaleCommand entity with a randomly generated SaleId.</returns>
    public static GetSaleCommand GenerateValidCommand()
    {
        return getSaleCommandFaker.Generate();
    }

    /// <summary>
    ///     Generates a fake Sale entity with realistic data for testing retrieval.
    ///     Useful for mocking return values from repository.
    /// </summary>
    /// <returns>A Sale entity populated with valid random data.</returns>
    public static Sale GenerateMockSale()
    {
        var saleFaker = new Faker<Sale>()
            .RuleFor(s => s.Id, f => f.Random.Guid())
            .RuleFor(s => s.SaleNumber, f => f.Random.AlphaNumeric(10))
            .RuleFor(s => s.SaleDate, f => f.Date.Past())
            .RuleFor(s => s.Customer, f => f.PickRandom<Customer>())
            .RuleFor(s => s.Branch, f => f.PickRandom<Branch>())
            .RuleFor(s => s.Items, (f, sale) => new List<SaleItem>
            {
                new(sale.Id, f.PickRandom<Product>(), f.Random.Int(1, 5), f.Finance.Amount())

                {
                    Product = f.PickRandom<Product>(),
                    Quantity = f.Random.Int(1, 5),
                    UnitPrice = f.Finance.Amount()
                }
            });

        return saleFaker.Generate();
    }
}