using Ambev.DeveloperEvaluation.Application.Sale.CreateSaleItem;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale;

/// <summary>
///     Validator for CreateSaleCommand that defines validation rules for sale creation command.
/// </summary>
public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    /// <summary>
    ///     Validates instances of <see cref="CreateSaleCommand" />.
    /// </summary>
    /// <remarks>
    ///     Validation rules include:
    ///     - SaleNumber: Required, length between 5 and 20 characters.
    ///     - SaleDate: Must be in the past or present.
    ///     - Customer: Must be a valid enumeration value.
    ///     - Branch: Must be a valid enumeration value.
    ///     - Items: Must not be empty; each item validated using <see cref="CreateSaleItemCommandValidator" />.
    /// </remarks>
    public CreateSaleCommandValidator()
    {
        RuleFor(sale => sale.SaleNumber).NotEmpty().Length(5, 20);
        RuleFor(sale => sale.SaleDate).LessThanOrEqualTo(DateTime.Now);
        RuleFor(sale => sale.Customer).IsInEnum();
        RuleFor(sale => sale.Branch).IsInEnum();
        RuleFor(sale => sale.Items).NotEmpty();
        RuleForEach(sale => sale.Items).SetValidator(new CreateSaleItemCommandValidator());
    }
}