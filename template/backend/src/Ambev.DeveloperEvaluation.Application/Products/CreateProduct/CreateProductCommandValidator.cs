using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
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
