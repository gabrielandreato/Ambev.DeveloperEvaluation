using Ambev.DeveloperEvaluation.Application.Sale.UpdateSaleItem;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData;

public static class UpdateSaleItemHandlerTestData
{
    public static UpdateSaleItemCommand GenerateValidCommand()
    {
        return new Faker<UpdateSaleItemCommand>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.Product, f => f.PickRandom(Product.ProductA, Product.ProductB, Product.ProductC))
            .RuleFor(x => x.Quantity, f => f.Random.Int(1, 10))
            .RuleFor(x => x.UnitPrice, f => f.Finance.Amount());
    }

    public static SaleItem GenerateMockSaleItem(Guid id, bool isCancelled = false)
    {
        return new SaleItem(
            id,
            Product.ProductA,
            10,
            15.5m,
            isCancelled
        );
    }
}