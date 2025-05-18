using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateAsync(Customer user, CancellationToken cancellationToken = default);

        Task<Customer> UpdateAsync(Customer user, CancellationToken cancellationToken = default);

        Task<Customer?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
