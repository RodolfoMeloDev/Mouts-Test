using Ambev.DeveloperEvaluation.Application.OrderItems.CreateOrderItens;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.CreateOrder.CreateOrderItem
{
    public class CreateOrderItemProfile : Profile
    {
        public CreateOrderItemProfile()
        {
            CreateMap<CreateOrderItemRequest, CreateOrderItensCommand>();
            CreateMap<CreateOrderItensResult, CreateOrderItemResponse>();
        }
    }
}
