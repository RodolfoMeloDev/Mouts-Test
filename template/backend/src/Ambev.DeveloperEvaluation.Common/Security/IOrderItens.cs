namespace Ambev.DeveloperEvaluation.Common.Security
{
    public interface IOrderItens
    {
        public int Id { get; }

        public int OrderId { get; }

        public int ProductId { get; }

        public int Quantities { get; }

        public decimal UnitPrice{ get; }
    }
}
