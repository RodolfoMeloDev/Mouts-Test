namespace Ambev.DeveloperEvaluation.Common.Security
{
    public interface ICustomer
    {
        public int Id { get; }

        public string CustomerName { get; }

        public string Status { get; }
    }
}
