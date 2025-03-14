using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;


/// <summary>
/// Validator for CreateSaleItemRequest that defines validation rules for user creation.
/// </summary>
public class CreateSaleItemRequestValidator: AbstractValidator<CreateSaleItemRequest>
{
    /// <summary>
    /// Validates instances of <see cref="CreateSaleItemRequest"/>.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Product: Must be a valid enumeration value.
    /// - Quantity: Must be greater than zero.
    /// - UnitPrice: Must be greater than or equal to zero.
    /// - Discount: Must be greater than or equal to zero.
    /// </remarks>
    public CreateSaleItemRequestValidator()
    {
        RuleFor(item => item.Product).IsInEnum();
        RuleFor(item => item.Quantity).GreaterThan(0);
        RuleFor(item => item.UnitPrice).GreaterThanOrEqualTo(0);
        RuleFor(item => item.Discount).GreaterThanOrEqualTo(0);
    }
}