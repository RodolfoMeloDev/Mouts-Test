using Ambev.DeveloperEvaluation.WebApi.Features.Orders.CreateOrder.CreateOrderItem;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.CreateOrder
{
    public class CreateOrderRequest
    {
        public DateOnly DateOrder { get; set; }

        public int CustomerId { get; set; }

        public string Branch { get; set; } = string.Empty;

        public List<CreateOrderItemRequest> Itens { get; set; } = [];
    }
}
