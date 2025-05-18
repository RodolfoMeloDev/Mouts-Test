using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order order, CancellationToken cancellationToken = default);

        Task<Order?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<Order?> GetByCustomerIdAsync(int customerId, CancellationToken cancellationToken = default);

        Task<bool> CanceledAsync(int id, CancellationToken cancellationToken = default);
    }
}
