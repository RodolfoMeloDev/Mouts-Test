using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Email).SetValidator(new EmailValidator());

            RuleFor(customer => customer.Birthday).SetValidator(new BirthdayValidator());

            RuleFor(customer => customer.CustomerName)
                .NotEmpty()
                .MinimumLength(3).WithMessage("CustomerName must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("CustomerName cannot be longer than 50 characters.");

            RuleFor(customer => customer.Address)
                .NotEmpty()
                .MaximumLength(250).WithMessage("Address cannot be longer than 250 characters.");

            RuleFor(customer => customer.Phone)
                .Matches(@"^\+[1-9]\d{10,14}$")
                .WithMessage("Phone number must start with '+' followed by 11-15 digits.");

            RuleFor(customer => customer.Complement)
                .MaximumLength(1000).WithMessage("Address cannot be longer than 1000 characters.");

            RuleFor(customer => customer.Status)
                .NotEqual(CustomerStatus.Unknown)
                .WithMessage("Customer status cannot be Unknown.");

        }
    }
}
