using Ambev.DeveloperEvaluation.Application.Sale.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    /// <summary>
    /// Provides methods for generating test data using the Bogus library.
    /// This class centralizes all test data generation to ensure consistency
    /// across test cases and provide both valid and invalid data scenarios.
    /// </summary>
    public static class UpdateSaleHandlerTestData
    {
        /// <summary>
        /// Configures the Faker to generate valid UpdateSaleCommand entities.
        /// The generated sales will have valid:
        /// - SaleNumber: Randomly generated alphanumeric string
        /// - SaleDate: A random date in the past year
        /// - Customer: Valid enum value
        /// - Branch: Valid enum value
        /// - Items: At least one valid SaleItem
        /// </summary>
        private static readonly Faker<UpdateSaleCommand> updateSaleCommandFaker = new Faker<UpdateSaleCommand>()
            .RuleFor(s => s.SaleNumber, f => f.Random.AlphaNumeric(10))
            .RuleFor(s => s.SaleDate, f => f.Date.Past(1))
            .RuleFor(s => s.Customer, f => f.PickRandom<Customer>())
            .RuleFor(s => s.Branch, f => f.PickRandom<Branch>());

        /// <summary>
        /// Generates a valid UpdateSaleCommand entity with randomized data.
        /// The generated sale will have all properties populated with valid values
        /// that meet the system's validation requirements.
        /// </summary>
        /// <returns>A valid UpdateSaleCommand entity with randomly generated data.</returns>
        public static UpdateSaleCommand GenerateValidCommand()
        {
            return updateSaleCommandFaker.Generate();
        }
        
    }
}