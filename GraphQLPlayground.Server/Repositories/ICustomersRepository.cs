using GraphQLPlayground.Server.Models;

namespace GraphQLPlayground.Server.Repositories
{
    public interface ICustomersRepository
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(Guid id);
        Task<List<Customer>> GetCustomersByNameAsync(string name);
        Task<List<Customer>> GetCustomersByLastNameAsync(string lastName);
        Task<Customer> CreateCustomerAsync(Customer customer);
    }
}
