using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.OrderItems.CreateOrderItens
{
    public class CreateOrderItensCommand
    {
        public int ProductId { get; set; }

        public Product? Product { get; set; }

        public int Quantities { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
