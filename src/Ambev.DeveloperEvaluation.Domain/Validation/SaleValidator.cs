using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(sale => sale.SaleNumber)
                .NotEmpty().WithMessage("Sale number is required.")
                .MinimumLength(5).WithMessage("Sale number must be at least 5 characters long.")
                .MaximumLength(20).WithMessage("Sale number cannot be longer than 20 characters.");

            RuleFor(sale => sale.SaleDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Sale date must be in the past or present.");
            
            RuleFor(sale => sale.Customer)
                .IsInEnum().WithMessage("Customer is not valid.");

            RuleFor(sale => sale.Branch)
                .IsInEnum().WithMessage("Branch is not valid.");

            RuleFor(sale => sale.Items)
                .NotEmpty().WithMessage("At least one item must be included in the sale.");
            
            RuleForEach(sale => sale.Items).SetValidator(new SaleItemValidator());
        }
    }
    
}