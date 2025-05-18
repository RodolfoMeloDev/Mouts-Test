using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.ProductName)
                .NotEmpty()
                .MinimumLength(3).WithMessage("ProductName must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("ProductName cannot be longer than 50 characters.");

            RuleFor(product => product.Description)
                .MaximumLength(250).WithMessage("Description cannot be longer than 250 characters.");

            RuleFor(product => product.BarCode)
                .MaximumLength(50).WithMessage("BarCode cannot be longer than 250 characters.");
        }
    }
}
