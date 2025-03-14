using Ambev.DeveloperEvaluation.Application.Sale.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    /// <summary>
    /// Provides methods for generating test data using the Bogus library.
    /// This class centralizes all test data generation to ensure consistency
    /// across test cases and provide both valid and invalid data scenarios.
    /// </summary>
    public static class CreateSaleHandlerTestData
    {
        /// <summary>
        /// Configures the Faker to generate valid Sale entities.
        /// The generated sales will have valid:
        /// - SaleNumber: Randomly generated alphanumeric string
        /// - SaleDate: A random date in the past year
        /// - Customer: Valid enum value
        /// - Branch: Valid enum value
        /// - Items: At least one valid SaleItem
        /// </summary>
        private static readonly Faker<CreateSaleCommand> createSaleCommandFaker = new Faker<CreateSaleCommand>()
            .RuleFor(s => s.SaleNumber, f => f.Random.AlphaNumeric(10))
            .RuleFor(s => s.SaleDate, f => f.Date.Past(1))
            .RuleFor(s => s.Customer, f => f.PickRandom<Customer>())
            .RuleFor(s => s.Branch, f => f.PickRandom<Branch>())
            .RuleFor(s => s.Items, f => GenerateSaleItems());

        /// <summary>
        /// Generates a valid Sale entity with randomized data.
        /// The generated sale will have all properties populated with valid values
        /// that meet the system's validation requirements.
        /// </summary>
        /// <returns>A valid Sale entity with randomly generated data.</returns>
        public static CreateSaleCommand GenerateValidCommand()
        {
            return createSaleCommandFaker.Generate();
        }

        /// <summary>
        /// Generates a list of SaleItem entities with randomized data.
        /// </summary>
        /// <returns>A list of SaleItem with valid and random data.</returns>
        private static List<CreateSaleItemCommand> GenerateSaleItems()
        {
            var fakeSaleItem = new Faker<CreateSaleItemCommand>()
                .RuleFor(i => i.Product, f => f.PickRandom<Product>())
                .RuleFor(i => i.Quantity, f => f.Random.Int(1, 20))
                .RuleFor(i => i.UnitPrice, f => f.Finance.Amount())
                .RuleFor(i => i.Discount, f => f.Random.Decimal(0, 0.2m) * f.Finance.Amount());

            return fakeSaleItem.GenerateBetween(1, 5); // Generates between 1 and 5 items for demonstration
        }
    }
}