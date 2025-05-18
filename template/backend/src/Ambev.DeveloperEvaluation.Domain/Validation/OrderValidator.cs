using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(sale => sale.DateOrder)
                .GreaterThan(DateTime.Today)
                .WithMessage("Order Sale must be less than or equal to today");

            RuleFor(sale => sale.CustomerId)
               .NotEmpty()
               .NotNull()
               .WithMessage("CustomerId must be informated");

            RuleFor(sale => sale.Branch)
               .NotEmpty()
               .MinimumLength(3).WithMessage("Branch must be at least 3 characters long.")
               .MaximumLength(100).WithMessage("Branch cannot be longer than 100 characters.");

            RuleFor(sale => sale.TotalOrder)
               .LessThanOrEqualTo(0)
               .WithMessage("Total order must be greater zero");
        }
    }
}
