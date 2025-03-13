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

            RuleFor(sale => sale.CustomerId)
                .NotEmpty().WithMessage("Customer ID is required.");

            RuleFor(sale => sale.CustomerName)
                .NotEmpty().WithMessage("Customer name is required.")
                .MaximumLength(100).WithMessage("Customer name cannot be longer than 100 characters.");

            RuleFor(sale => sale.BranchId)
                .NotEmpty().WithMessage("Branch ID is required.");

            RuleFor(sale => sale.BranchName)
                .NotEmpty().WithMessage("Branch name is required.")
                .MaximumLength(100).WithMessage("Branch name cannot be longer than 100 characters.");

            RuleFor(sale => sale.Items)
                .NotEmpty().WithMessage("At least one item must be included in the sale.");
            
            RuleForEach(sale => sale.Items).SetValidator(new SaleItemValidator());
        }
    }
    
}