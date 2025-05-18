using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomer
{
    public class GetCustomerRequestValidator : AbstractValidator<GetCustomerRequest>
    {
        public GetCustomerRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Customer ID is required")
                .GreaterThan(0)
                .WithMessage("Customer ID must be greather ZERO");
        }
    }
}
