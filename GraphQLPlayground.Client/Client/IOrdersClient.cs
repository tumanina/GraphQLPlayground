using GraphQLPlayground.Client.Models;

namespace GraphQLPlayground.Client.Client
{
    public interface IOrdersClient
    {
        Task<List<Order>> GetOrdersAsync();
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> CreateCustomerAsync(string firstName, string lastName, string notes);
    }
}