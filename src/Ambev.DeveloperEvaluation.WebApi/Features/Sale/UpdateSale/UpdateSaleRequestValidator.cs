using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.UpdateSale;

/// <summary>
///     Validator for UpdateSaleRequest that defines validation rules for user update.
/// </summary>
public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
{
    /// <summary>
    ///     Validates instances of <see cref="UpdateSaleRequest" />.
    /// </summary>
    /// <remarks>
    ///     Validation rules include:
    ///     - SaleNumber: Required, length between 5 and 20 characters.
    ///     - SaleDate: Must be in the past or present.
    ///     - Customer: Must be a valid enumeration value.
    ///     - Branch: Must be a valid enumeration value.
    /// </remarks>
    public UpdateSaleRequestValidator()
    {
        RuleFor(sale => sale.SaleNumber).NotEmpty().Length(5, 20);
        RuleFor(sale => sale.SaleDate).LessThanOrEqualTo(DateTime.Now);
        RuleFor(sale => sale.Customer).IsInEnum();
        RuleFor(sale => sale.Branch).IsInEnum();
    }
}