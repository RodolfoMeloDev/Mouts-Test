using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.OrderItems.CreateOrderItens
{
    public class CreateOrdersItensProfile : Profile
    {
        public CreateOrdersItensProfile()
        {
            CreateMap<CreateOrderItensCommand, OrderItens>();
            CreateMap<OrderItens, CreateOrderItensResult>();
        }
    }
}
