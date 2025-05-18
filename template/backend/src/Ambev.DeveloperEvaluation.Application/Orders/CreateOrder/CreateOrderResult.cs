using Ambev.DeveloperEvaluation.Application.OrderItems.CreateOrderItens;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Orders.CreateOrder
{
    public class CreateOrderResult
    {
        public int Id { get; set; }

        public DateOnly DateOrder { get; set; }

        public int CustomerId { get; set; }

        public string Branch { get; set; } = string.Empty;

        public ICollection<CreateOrderItensResult> Itens { get; set; } = [];

        public OrderStatus Status { get; set; }

        public decimal TotalOrder { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
