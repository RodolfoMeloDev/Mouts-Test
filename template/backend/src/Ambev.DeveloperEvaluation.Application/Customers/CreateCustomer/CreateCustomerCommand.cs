using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<CreateCustomerResult>
    {
        public string CustomerName { get; set; } = string.Empty;

        public DateTime Birthday { get; set; }

        public string Address { get; set; } = string.Empty;

        public string NumberAdrress { get; set; } = string.Empty;

        public string Complement { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public CustomerStatus Status { get; set; }

        public ValidationResultDetail Validate()
        {
            var validator = new CreateCustomerCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
