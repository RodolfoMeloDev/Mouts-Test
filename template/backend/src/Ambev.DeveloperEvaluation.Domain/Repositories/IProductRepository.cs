using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product user, CancellationToken cancellationToken = default);

        Task<Product> UpdateAsync(Product user, CancellationToken cancellationToken = default);

        Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<Product?> GetByNameAsync(string name, CancellationToken cancellationToken = default);

        Task<IEnumerable<Product>?> GetByListIdAsync(IEnumerable<int> listId, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
