using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class SaleTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Sale entities.
    /// The generated sales will have valid:
    /// - Sale number
    /// - Sale date
    /// - Customer ID and name
    /// - Branch ID and name
    /// - Total amount
    /// - Cancellation status
    /// - List of sale items
    /// </summary>
    private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
        .CustomInstantiator(f => new Sale())
        .RuleFor(s => s.SaleNumber, f => $"{f.Commerce.Ean13()}")
        .RuleFor(s => s.SaleDate, f => f.Date.Past())
        .RuleFor(s => s.Customer, f => f.PickRandom(Customer.CustomerA, Customer.CustomerB, Customer.CustomerC))
        .RuleFor(s => s.Branch, f => f.PickRandom(Branch.BranchA, Branch.BranchB, Branch.BranchC))
        .RuleFor(s => s.IsCancelled, f => f.Random.Bool())
        .RuleFor(s => s.Items, (f, sale) => GenerateSaleItems(sale.Id));

    /// <summary>
    /// Generates a valid Sale entity with randomized data.
    /// The generated user will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Sale entity with randomly generated data.</returns>
    public static Sale GenerateValidSale()
    {
        var sale = SaleFaker.Generate();
        return sale;
    }

    /// <summary>
    /// Generates a list of SaleItem entities with randomized data.
    /// </summary>
    /// <returns>A list of SaleItem with random data.</returns>
    private static List<SaleItem> GenerateSaleItems(Guid saleId)
    {
        var faker = new Faker<SaleItem>()
            .CustomInstantiator(f => new SaleItem(
                saleId,
                f.PickRandom(Product.ProductA, Product.ProductB, Product.ProductC),
                f.Random.Number(1, 5),
                f.Random.Decimal(0m, 100m),
                f.Random.Decimal(0m, 20m)
            ));

        return faker.Generate(2); 
    }
}