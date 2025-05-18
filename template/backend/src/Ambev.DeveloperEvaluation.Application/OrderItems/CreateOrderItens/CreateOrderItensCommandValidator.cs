using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.OrderItems.CreateOrderItens
{
    public class CreateOrderItensCommandValidator : AbstractValidator<CreateOrderItensCommand>
    {
        public CreateOrderItensCommandValidator()
        {
            RuleFor(item => item.ProductId)
                .NotEmpty()
                .WithMessage("Product ID is required")
                .GreaterThan(0)
                .WithMessage("Product ID must be greather ZERO");

            RuleFor(item => item.Quantities)
                .NotEmpty()
                .WithMessage("Quantities is required")
                .GreaterThan(0)
                .WithMessage("Quantities must be greather ZERO")
                .LessThanOrEqualTo(20)
                .WithMessage("Quantities must be less or equal 20");

            RuleFor(item => item.UnitPrice)
                .NotEmpty()
                .WithMessage("UnitPrice is required")
                .GreaterThan(0)
                .WithMessage("UnitPrice must be greather ZERO");
        }
    }
}
