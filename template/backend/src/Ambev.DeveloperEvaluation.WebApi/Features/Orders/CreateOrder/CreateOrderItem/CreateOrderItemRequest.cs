namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.CreateOrder.CreateOrderItem
{
    public class CreateOrderItemRequest
    {
        public int ProductId { get; set; }

        public int Quantities { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
