using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DefaultContext _context;

        public ProductRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
        {
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }

        public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Products.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var product = await GetByIdAsync(id, cancellationToken);
            if (product == null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(product.Id, cancellationToken) ??
                throw new KeyNotFoundException("A chave de identificação do objeto não foi encontrada, não foi possível atualizar as informações.");
            product.UpdatedAt = DateTime.UtcNow;

            _context.Entry(entity).CurrentValues.SetValues(product);

            await _context.SaveChangesAsync(cancellationToken);

            return product;
        }

        public async Task<Product?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _context.Products.FirstOrDefaultAsync(o => o.ProductName.Equals(name), cancellationToken);
        }

        public async Task<IEnumerable<Product>?> GetByListIdAsync(IEnumerable<int> listId, CancellationToken cancellationToken)
        {
            return await _context.Products.Where(f => listId.Contains(f.Id)).ToListAsync();
        }
    }
}
