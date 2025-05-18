using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IOrderItemRepository
    {
        Task<OrderItens> CreateAsync(OrderItens item, CancellationToken cancellationToken = default);

        Task<IEnumerable<OrderItens>> CreateRangeAsync(List<OrderItens> itens, CancellationToken cancellationToken = default);
    }
}
