namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    public class CreateProductRequest
    {
        public string ProductName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string BarCode { get; set; } = string.Empty;
    }
}
