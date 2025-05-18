using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Features.Orders.CreateOrder.CreateOrderItem;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.CreateOrder
{
    public class CreateOrderResponse
    {
        public int Id { get; set; }

        public DateOnly DateOrder { get; set; }

        public int CustomerId { get; set; }

        public string Branch { get; set; } = string.Empty;

        public OrderStatus Status { get; set; }

        public decimal TotalOrder { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<CreateOrderItemResponse>? Itens { get; set; }
    }
}
