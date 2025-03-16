using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sale.UpdateSale;

/// <summary>
///     Validator for UpdateSaleCommand that defines validation rules for user Updation command.
/// </summary>
public class UpdateSaleCommandValidator : AbstractValidator<UpdateSaleCommand>
{
    /// <summary>
    ///     Validates instances of <see cref="UpdateSaleCommand" />.
    /// </summary>
    /// <remarks>
    ///     Validation rules include:
    ///     - SaleNumber: Required, length between 5 and 20 characters.
    ///     - SaleDate: Must be in the past or present.
    ///     - Customer: Must be a valid enumeration value.
    ///     - Branch: Must be a valid enumeration value.
    /// </remarks>
    public UpdateSaleCommandValidator()
    {
        RuleFor(sale => sale.SaleNumber).NotEmpty().Length(5, 20);
        RuleFor(sale => sale.SaleDate).LessThanOrEqualTo(DateTime.Now);
        RuleFor(sale => sale.Customer).IsInEnum();
        RuleFor(sale => sale.Branch).IsInEnum();
    }
}