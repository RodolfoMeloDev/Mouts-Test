using Ambev.DeveloperEvaluation.Application.Customers.GetCustomer;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomer;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct
{
    public class GetProductProfile : Profile
    {
        public GetProductProfile()
        {
            CreateMap<int, GetProductCommand>()
                .ConstructUsing(id => new GetProductCommand(id));
            CreateMap<GetProductResult, GetProductResponse>();
        }
    }
}
