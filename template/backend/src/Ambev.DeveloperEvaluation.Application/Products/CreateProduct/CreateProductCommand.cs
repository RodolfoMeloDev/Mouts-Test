using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductResult>
    {
        public string ProductName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string BarCode { get; set; } = string.Empty;

        public ProductStatus Status { get; set; } = ProductStatus.Active;

        public ValidationResultDetail Validate()
        {
            var validator = new CreateProductCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
