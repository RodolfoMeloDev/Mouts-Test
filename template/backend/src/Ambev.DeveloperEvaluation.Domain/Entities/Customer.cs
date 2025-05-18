using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Customer : ICustomer
    {
        public int Id {  get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public DateTime Birthday { get; set; }

        public string Address { get; set; } = string.Empty;

        public string NumberAdrress {  get; set; } = string.Empty;  

        public string Complement { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public CustomerStatus Status {  get; set; } = CustomerStatus.Unknown;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        string ICustomer.Status => Status.ToString();

        public  ICollection<Order>? Order { get; set; }

        public ValidationResultDetail Validate()
        {
            var validator = new CustomerValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        public void Activate()
        {
            Status = CustomerStatus.Active;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            Status = CustomerStatus.Inactive;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Blocks the user account.
        /// Changes the user's status to Blocked.
        /// </summary>
        public void Suspend()
        {
            Status = CustomerStatus.Suspended;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
