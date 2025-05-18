using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DefaultContext _context;

        public CustomerRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Customer> CreateAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            await _context.Customers.AddAsync(customer, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return customer;
        }

        public async Task<Customer?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Customers.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var customer = await GetByIdAsync(id, cancellationToken);
            if (customer == null)
                return false;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<Customer> UpdateAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(customer.Id, cancellationToken) ??
                throw new KeyNotFoundException("A chave de identificação do objeto não foi encontrada, não foi possível atualizar as informações.");
            customer.UpdatedAt = DateTime.UtcNow;
            customer.CreatedAt = entity.CreatedAt;

            _context.Entry(entity).CurrentValues.SetValues(customer);

            await _context.SaveChangesAsync(cancellationToken);

            return customer;
        }
    }
}
