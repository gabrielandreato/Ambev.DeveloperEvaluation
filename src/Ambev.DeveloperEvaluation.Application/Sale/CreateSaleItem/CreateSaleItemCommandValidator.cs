using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale;

/// <summary>
/// Validator for CreateSaleItemCommand that defines validation rules for user creation command.
/// </summary>
public class CreateSaleItemCommandValidator: AbstractValidator<CreateSaleItemCommand>
{
    /// <summary>
    /// Validates instances of <see cref="CreateSaleItemCommand"/>.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Product: Must be a valid enumeration value.
    /// - Quantity: Must be greater than zero.
    /// - UnitPrice: Must be greater than or equal to zero.
    /// - Discount: Must be greater than or equal to zero.
    /// </remarks>
    public CreateSaleItemCommandValidator()
    {
        RuleFor(item => item.Product).IsInEnum();
        RuleFor(item => item.Quantity).GreaterThan(0);
        RuleFor(item => item.UnitPrice).GreaterThanOrEqualTo(0);
        RuleFor(item => item.Discount).GreaterThanOrEqualTo(0);
    }
}