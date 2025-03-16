using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sale.GetSale;

/// <summary>
///     Validator for GetSaleCommand that defines validation rules for sale get command.
/// </summary>
public class GetSaleCommandValidator : AbstractValidator<GetSaleCommand>
{
    /// <summary>
    ///     Validates instances of <see cref="GetSaleCommand" />.
    /// </summary>
    /// <remarks>
    ///     Validation rules include:
    ///     - Id: Required
    /// </remarks>
    public GetSaleCommandValidator()
    {
        RuleFor(sale => sale.Id).NotEmpty();
    }
}