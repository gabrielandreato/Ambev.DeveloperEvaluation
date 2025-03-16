using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData;

public static class GetListSaleHandlerTestData
{
    public static List<Sale> GenerateMockSales(int count = 10)
    {
        var saleFaker = new Faker<Sale>()
            .RuleFor(s => s.Id, f => f.Random.Guid())
            .RuleFor(s => s.SaleNumber, f => f.Random.AlphaNumeric(10))
            .RuleFor(s => s.SaleDate, f => f.Date.Past())
            .RuleFor(s => s.Customer, f => f.PickRandom<Customer>())
            .RuleFor(s => s.Branch, f => f.PickRandom<Branch>())
            .RuleFor(s => s.IsCancelled, f => f.Random.Bool())
            .RuleFor(s => s.Items, (f, sale) => new List<SaleItem>
            {
                new(sale.Id, f.PickRandom<Product>(), f.Random.Int(1, 5), f.Finance.Amount())
            });

        return saleFaker.Generate(count);
    }
}