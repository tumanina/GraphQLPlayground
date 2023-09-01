using GraphQLPlayground.Server.Data;
using GraphQLPlayground.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLPlayground.Server.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly OrdersDbContext _dbContext;

        public OrdersRepository(OrdersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _dbContext.Orders.Include(r => r.Customer).ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(Guid id)
        {
            return await _dbContext.Orders.Include(r => r.Customer).FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
