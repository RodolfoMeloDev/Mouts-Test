using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class OrderItensValidator : AbstractValidator<OrderItens>
    {
        public OrderItensValidator()
        {
            RuleFor(item => item.OrderId)
               .NotEmpty()
               .WithMessage("OrderId must be informated");

            RuleFor(item => item.ProductId)
               .NotEmpty()
               .WithMessage("ProductId must be informated");

            RuleFor(item => item.UnitPrice)
               .GreaterThan(0)
               .WithMessage("UnitPrice must be greather zero");

            RuleFor(item => item.Quantities)
               .GreaterThan(0)
               .LessThanOrEqualTo(20)
               .WithMessage("Quantities must be greather 0 and less or equal 20");
        }
    }
}
