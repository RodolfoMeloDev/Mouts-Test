using Ambev.DeveloperEvaluation.Application.OrderItems.CreateOrderItens;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderResult>
    {
        public DateOnly DateOrder { get; set; }

        public int CustomerId { get; set; }

        public Customer? Customer { get; set; }

        public string Branch { get; set; } = string.Empty;

        public List<CreateOrderItensCommand> Itens { get; set; } = [];

        public ValidationResultDetail Validate()
        {
            var validator = new CreateOrderCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
