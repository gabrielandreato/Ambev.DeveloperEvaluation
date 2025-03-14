using Ambev.DeveloperEvaluation.Application.Sale.GetListSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;
using System;
using System.Collections.Generic;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    public static class GetListSaleHandlerTestData
    {
        public static List<Sale> GenerateMockSales()
        {
            var saleFaker = new Faker<Sale>()
                .RuleFor(s => s.Id, f => f.Random.Guid())
                .RuleFor(s => s.SaleNumber, f => f.Random.AlphaNumeric(10))
                .RuleFor(s => s.SaleDate, f => f.Date.Past(1))
                .RuleFor(s => s.Customer, f => f.PickRandom<Customer>())
                .RuleFor(s => s.Branch, f => f.PickRandom<Branch>())
                .RuleFor(s => s.IsCancelled, f => f.Random.Bool())
                .RuleFor(s => s.Items, f => new List<SaleItem>
                {
                    new SaleItem
                    {
                        Product = f.PickRandom<Product>(),
                        Quantity = f.Random.Int(1, 5),
                        UnitPrice = f.Finance.Amount(),
                        Discount = f.Random.Decimal(0, 0.2m) * f.Finance.Amount()
                    }
                });

            return saleFaker.GenerateBetween(5, 10);
        }

        public static List<Sale> GenerateFilteredMockSales()
        {
            var saleFaker = new Faker<Sale>()
                .RuleFor(s => s.Id, f => f.Random.Guid())
                .RuleFor(s => s.SaleNumber, f => "12345")  // Specific to satisfy filter
                .RuleFor(s => s.SaleDate, f => f.Date.Between(DateTime.Now.AddDays(-30), DateTime.Now))
                .RuleFor(s => s.Customer, f => Customer.CustomerA)  // Matches filter
                .RuleFor(s => s.Branch, f => Branch.BranchA)  // Matches filter
                .RuleFor(s => s.IsCancelled, f => false)  // Matches filter
                .RuleFor(s => s.Items, f => new List<SaleItem>
                {
                    new SaleItem
                    {
                        Product = f.PickRandom<Product>(),
                        Quantity = f.Random.Int(1, 5),
                        UnitPrice = f.Finance.Amount(),
                        Discount = f.Random.Decimal(0, 0.2m) * f.Finance.Amount()
                    }
                });

            return saleFaker.GenerateBetween(1, 5);
        }
    }
}