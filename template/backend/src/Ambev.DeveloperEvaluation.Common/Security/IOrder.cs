namespace Ambev.DeveloperEvaluation.Common.Security
{
    public interface IOrder
    {
        int Id { get; }
        
        DateTime DateOrder { get; }
        
        int CustomerId { get;  }

        string Status { get; }

        decimal TotalOrder { get; }
    }
}
