﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;

/// <summary>
/// Validator for CreateSaleRequest that defines validation rules for user creation.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    /// <summary>
    /// Validates instances of <see cref="CreateSaleRequest"/>.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - SaleNumber: Required, length between 5 and 20 characters.
    /// - SaleDate: Must be in the past or present.
    /// - Customer: Must be a valid enumeration value.
    /// - Branch: Must be a valid enumeration value.
    /// - Items: Must not be empty; each item validated using <see cref="CreateSaleItemRequestValidator"/>.
    /// </remarks>
    public CreateSaleRequestValidator()
    {
        RuleFor(sale => sale.SaleNumber).NotEmpty().Length(5, 20);
        RuleFor(sale => sale.SaleDate).LessThanOrEqualTo(DateTime.Now);
        RuleFor(sale => sale.Customer).IsInEnum();
        RuleFor(sale => sale.Branch).IsInEnum();
        RuleFor(sale => sale.Items).NotEmpty();
        RuleForEach(sale => sale.Items).SetValidator(new CreateSaleItemRequestValidator());
    }
}