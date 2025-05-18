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

            RuleFor(item => item.Discount)
               .Must((product, discount) =>
               {
                   if (product.Quantities < 4)
                       return discount == 0;

                   if (product.Quantities <= 10)
                       return discount == product.Quantities * product.UnitPrice * 0.9m;

                   if (product.Quantities <= 10)
                       return discount == product.Quantities * product.UnitPrice * 0.8m;

                   return true;
               })
               .WithMessage("Discount invalite");

            RuleFor(item => item.TotalPrice)
               .GreaterThan(0)
               .WithMessage("TotalPrice must be greather zero");
        }
    }
}
