namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.CreateOrder.CreateOrderItem
{
    public class CreateOrderItemResponse
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantities { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal? Discount { get; set; }

        public decimal TotalPrice { get; set; }

        public bool? Canceled { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
