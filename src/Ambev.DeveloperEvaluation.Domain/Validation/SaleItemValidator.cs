using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleItemValidator : AbstractValidator<SaleItem>
{
    public SaleItemValidator()
    {
        RuleFor(item => item.Product)
            .IsInEnum().WithMessage("Product is not valid.");

        RuleFor(item => item.Quantity)
            .GreaterThan(0)
            .LessThan(20)
            .WithMessage("Quantity must be greater than zero and less than 20.");

        RuleFor(item => item.UnitPrice)
            .GreaterThanOrEqualTo(0).WithMessage("Unit price must be greater than or equal to zero.");

        RuleFor(item => item.Discount)
            .GreaterThanOrEqualTo(0).WithMessage("Discount must be greater than or equal to zero.");
    }
}