using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Orders.CreateOrder
{
    public class CreateOrderProfile : Profile
    {
        public CreateOrderProfile()
        {
            CreateMap<CreateOrderCommand, Order>()
                .ForMember(dest => dest.DateOrder, opt => opt.MapFrom(src => src.DateOrder.ToDateTime(TimeOnly.MinValue)))
                .ReverseMap()
                .ForMember(dest => dest.DateOrder, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.DateOrder)));

            CreateMap<Order, CreateOrderResult>()
                .ForMember(dest => dest.DateOrder, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.DateOrder)))
                .ReverseMap()
                .ForMember(dest => dest.DateOrder, opt => opt.MapFrom(src => src.DateOrder.ToDateTime(TimeOnly.MinValue)));
        }
    }
}
