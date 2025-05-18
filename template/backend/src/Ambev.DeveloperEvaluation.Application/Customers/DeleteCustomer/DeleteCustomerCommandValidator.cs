using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.DeleteCustomer
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Customer ID is required")
                .GreaterThan(0)
                .WithMessage("Customer ID must be greather ZERO");
        }
    }
}
