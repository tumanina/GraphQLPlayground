using GraphQLPlayground.Server.Data;
using GraphQLPlayground.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLPlayground.Server.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly OrdersDbContext _dbContext;

        public CustomersRepository(OrdersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _dbContext.Customers.Include(c => c.Orders).ToListAsync();
        }

        public async Task<List<Customer>> GetCustomersByLastNameAsync(string lastName)
        {
            return await _dbContext.Customers.Include(c => c.Orders).Where(r => r.LastName == lastName).ToListAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(Guid id)
        {
            return await _dbContext.Customers.Include(c => c.Orders).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Customer>> GetCustomersByNameAsync(string name)
        {
            return await _dbContext.Customers.Include(c => c.Orders).Where(r => r.FirstName == name).ToListAsync();
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }
    }
}
