using Ambev.DeveloperEvaluation.Application.OrderItems.CreateOrderItens;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Orders.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(order => order.DateOrder)
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow))
                .WithMessage($"DateOrder must be less or equal than today");

            RuleFor(order => order.CustomerId)
                .NotEmpty()
                .WithMessage("Customer ID is required")
                .GreaterThan(0)
                .WithMessage("Customer ID must be greather ZERO");

            RuleFor(order => order.Branch)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Branch must be at least 3 characters long.")
                .MaximumLength(100).WithMessage("Branch cannot be longer than 50 characters.");

            RuleFor(order => order.Itens)
                .NotEmpty()
                .WithMessage("The order must ave at least 1 item");

            RuleForEach(order => order.Itens)
                .SetValidator(new CreateOrderItensCommandValidator());

            RuleFor(x => x.Itens)
                .Custom((itens, context) =>
                {
                    var productGroup = itens
                        .GroupBy(i => i.ProductId);

                    foreach (var product in productGroup)
                    {
                        var productId = product.Key;
                        var TotalQuantities = product.Sum(x => x.Quantities);

                        if (TotalQuantities > 20)
                        {
                            context.AddFailure($"Itens with ProductId {productId}", "The sum of the item quantities must not be greater than 20");
                        }

                        var precos = product.Select(x => x.UnitPrice).Distinct().ToList();
                        if (precos.Count > 1)
                        {
                            context.AddFailure($"Itens with ProductId {productId}", "All items with the same ProductId must have the same Unit Price");
                        }
                    }
                });
        }
    }
}
