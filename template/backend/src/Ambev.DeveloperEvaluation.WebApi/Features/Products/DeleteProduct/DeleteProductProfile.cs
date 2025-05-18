using Ambev.DeveloperEvaluation.Application.Customers.DeleteCustomer;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.DeleteCustomer;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct
{
    public class DeleteProductProfile : Profile
    {
        public DeleteProductProfile()
        {
            CreateMap<int, DeleteProductCommand>()
                .ConstructUsing(id => new DeleteProductCommand(id));
            CreateMap<DeleteProductResult, DeleteProductResponse>();
        }
    }
}
