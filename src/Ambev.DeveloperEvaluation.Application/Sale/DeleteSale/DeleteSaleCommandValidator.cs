using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sale.DeleteSale;

/// <summary>
///     Validator for DeleteSaleCommand that defines validation rules for sale deletion command.
/// </summary>
public class DeleteSaleCommandValidator : AbstractValidator<DeleteSaleCommand>
{
    /// <summary>
    ///     Validates instances of <see cref="DeleteSaleCommand" />.
    /// </summary>
    /// <remarks>
    ///     Validation rules include:
    ///     - Id: Required
    /// </remarks>
    public DeleteSaleCommandValidator()
    {
        RuleFor(sale => sale.Id).NotEmpty();
    }
}