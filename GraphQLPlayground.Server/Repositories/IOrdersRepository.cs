using GraphQLPlayground.Server.Models;

namespace GraphQLPlayground.Server.Repositories
{
    public interface IOrdersRepository
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(Guid id);
    }
}
