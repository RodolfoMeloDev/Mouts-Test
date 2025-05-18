using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.DeleteCustomer
{
    public class DeleteCustomerRequestValidator : AbstractValidator<DeleteCustomerRequest>
    {
        public DeleteCustomerRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Customer ID is required")
                .GreaterThan(0)
                .WithMessage("Customer ID must be greather ZERO");
        }
    }
}
