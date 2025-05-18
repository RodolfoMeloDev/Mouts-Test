using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly DefaultContext _context;

        public OrderItemRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<OrderItens> CreateAsync(OrderItens item, CancellationToken cancellationToken = default)
        {
            await _context.OrderItens.AddAsync(item, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return item;
        }

        public async Task<IEnumerable<OrderItens>> CreateRangeAsync(List<OrderItens> itens, CancellationToken cancellationToken = default)
        {
            await _context.OrderItens.AddRangeAsync(itens, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return itens;
        }
    }
}
