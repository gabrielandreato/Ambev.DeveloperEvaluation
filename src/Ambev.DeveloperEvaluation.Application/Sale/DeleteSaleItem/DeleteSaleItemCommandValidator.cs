using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sale.DeleteSaleItem;

/// <summary>
///     Validator for DeleteSaleItemCommand that defines validation rules for sale deletion command.
/// </summary>
public class DeleteSaleItemCommandValidator : AbstractValidator<DeleteSaleItemCommand>
{
    /// <summary>
    ///     Validates instances of <see cref="DeleteSaleItemCommand" />.
    /// </summary>
    /// <remarks>
    ///     Validation rules include:
    ///     - Id: Required
    /// </remarks>
    public DeleteSaleItemCommandValidator()
    {
        RuleFor(saleItem => saleItem.Id).NotEmpty();
    }
}