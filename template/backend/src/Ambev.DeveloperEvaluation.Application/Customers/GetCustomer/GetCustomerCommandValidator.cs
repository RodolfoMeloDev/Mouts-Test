using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomer
{
    public class GetCustomerCommandValidator : AbstractValidator<GetCustomerCommand>
    {
        public GetCustomerCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Customer ID is required")
                .GreaterThan(0)
                .WithMessage("Customer ID must be greather ZERO");
        }
    }
}
