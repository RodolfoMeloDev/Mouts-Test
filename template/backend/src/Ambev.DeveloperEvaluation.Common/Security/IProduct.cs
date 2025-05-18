namespace Ambev.DeveloperEvaluation.Common.Security
{
    public interface IProduct
    {
        public int Id { get; }

        public string ProductName { get; }

        public string Status { get; }
    }
}
