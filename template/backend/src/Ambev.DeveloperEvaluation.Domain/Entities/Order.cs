using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Order : IOrder
    {
        public int Id { get; set; }

        public DateTime DateOrder {  get; set; }

        public int CustomerId { get; set; }

        public Customer? Customer { get; set; }

        public string Branch { get; set; } = string.Empty;

        public OrderStatus Status { get; set; } = OrderStatus.Active;

        public decimal TotalOrder { get; set; }

        string IOrder.Status => Status.ToString();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public ICollection<OrderItens>? Itens{ get; set; }

        public ValidationResultDetail Validate()
        {
            var validator = new OrderValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        public void Activate()
        {
            Status = OrderStatus.Active;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            Status = OrderStatus.Inactive;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
