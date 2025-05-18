using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Product ID is required")
                .GreaterThan(0)
                .WithMessage("Product ID must be greather ZERO");

            RuleFor(user => user.ProductName)
                .NotEmpty()
                .MinimumLength(3).WithMessage("ProductName must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("ProductName cannot be longer than 50 characters.");

            RuleFor(customer => customer.Description)
                .MaximumLength(250).WithMessage("Description cannot be longer than 50 characters.");

            RuleFor(customer => customer.BarCode)
                .MaximumLength(50).WithMessage("BarCode cannot be longer than 50 characters.");
        }
    }
}
