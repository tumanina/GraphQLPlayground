using GraphQLPlayground.Client.Client;
using GraphQLPlayground.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLPlayground.Client.Controllers
{
    [ApiController]
    [Route("api")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersClient _client;

        public OrdersController(IOrdersClient client)
        {
            _client = client;
        }

        [HttpGet]
        [Route("orders")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _client.GetOrdersAsync();
            return Ok(orders);
        }

        [HttpGet]
        [Route("customers")]
        public async Task<IActionResult> GetCustomers()
        {
            var orders = await _client.GetCustomersAsync();
            return Ok(orders);
        }
        [HttpPost]
        [Route("customers")]
        public async Task<IActionResult> CreateCustomer(CreateCustomerModel createCustomerModel)
        {
            var orders = await _client.CreateCustomerAsync(createCustomerModel.FirstName, createCustomerModel.LastName, createCustomerModel.Notes);
            return Ok(orders);
        }
    }
}
