using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer
{
    public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(user => user.Email).SetValidator(new EmailValidator());
            
            RuleFor(user => user.CustomerName)
                .NotEmpty()
                .MinimumLength(3).WithMessage("CustomerName must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("CustomerName cannot be longer than 50 characters.");
            
            RuleFor(user => user.Birthday).SetValidator(new BirthdayValidator());
            
            RuleFor(user => user.Phone)
                .Matches(@"^\+?[1-9]\d{1,14}$")
                .WithMessage("Phone number must start with '+' followed by 11-15 digits.");
            
            RuleFor(user => user.Address)
                .NotEmpty()
                .MaximumLength(250).WithMessage("Address cannot be longer than 250 characters.");

            RuleFor(customer => customer.NumberAdrress)
                .MaximumLength(50).WithMessage("NumberAdrress cannot be longer than 50 characters.");

            RuleFor(customer => customer.Status)
                .NotEqual(CustomerStatus.Unknown)
                .WithMessage("Customer status cannot be Unknown.");
        }
    }
}
