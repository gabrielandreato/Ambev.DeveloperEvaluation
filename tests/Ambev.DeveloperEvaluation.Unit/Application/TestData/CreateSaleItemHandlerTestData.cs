using Ambev.DeveloperEvaluation.Application.Sale.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// </summary>
public static class CreateSaleItemHandlerTestData
{
    /// <summary>
    /// Generates a valid CreateSaleItemCommand entity with randomized data.
    /// </summary>
    public static CreateSaleItemCommand GenerateValidCommand()
    {
        return new Faker<CreateSaleItemCommand>()
            .RuleFor(c => c.SaleId, f => f.Random.Guid())
            .RuleFor(c => c.Product, f => f.PickRandom<Product>())
            .RuleFor(c => c.Quantity, f => f.Random.Int(1, 20))
            .RuleFor(c => c.UnitPrice, f => f.Finance.Amount())
            .RuleFor(c => c.Discount, f => f.Random.Decimal(0, 0.2m) * f.Finance.Amount());
    }

    /// <summary>
    /// Generates a mock Sale entity with default data for a valid sale.
    /// </summary>
    public static Sale GenerateMockSale()
    {
        return new Faker<Sale>()
            .RuleFor(s => s.Id, f => f.Random.Guid())
            .RuleFor(s => s.SaleNumber, f => f.Random.AlphaNumeric(10))
            .RuleFor(s => s.SaleDate, f => f.Date.Past(1))
            .RuleFor(s => s.Customer, f => f.PickRandom<Customer>())
            .RuleFor(s => s.Branch, f => f.PickRandom<Branch>())
            .RuleFor(s => s.IsCancelled, f => false)
            .RuleFor(s => s.Items, _ => new List<SaleItem>());
    }
}