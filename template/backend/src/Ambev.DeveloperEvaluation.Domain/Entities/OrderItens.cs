using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class OrderItens : IOrderItens
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; } = new Order();

        public int ProductId { get; set; }
        public Product Product { get; set; } = new Product();

        public int Quantities { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal? Discount { get; set; }

        public decimal TotalPrice { get; set; }

        public bool? Canceled { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public ValidationResultDetail Validate()
        {
            var validator = new OrderItensValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        public void CancelledItem()
        {
            Canceled = true;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
