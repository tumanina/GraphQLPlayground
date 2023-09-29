using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQLPlayground.Client.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GraphQLPlayground.Client.Client
{
    public class OrdersClient : IOrdersClient
    {
        public OrdersClient()
        {
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            using var client = new GraphQLHttpClient("https://localhost:7028/graphql", new NewtonsoftJsonSerializer
            {
                JsonSerializerSettings = { ContractResolver = new CamelCasePropertyNamesContractResolver() }
            });

            var response = await client.SendQueryAsync<OrdersResponse>(new GraphQL.GraphQLRequest
            {
                Query = @"
                    {
                        orders{
                            id,
                            status,
                            customer
                            {
                              id,
                              firstName,
                              lastName
                            }
                          }
                    }"
            });

            return response.Data.Orders;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            using var client = new GraphQLHttpClient("https://localhost:7028/graphql", new NewtonsoftJsonSerializer
            {
                JsonSerializerSettings = { ContractResolver = new CamelCasePropertyNamesContractResolver() }
            });

            var response = await client.SendQueryAsync<CustomersResponse>(new GraphQL.GraphQLRequest
            {
                Query = @"
                    {
                      customers{
                        id,
                        firstName,
                        lastName,
                        orders
                        {
                          id,
    	                    status
                        }   
                      }
                    }"
            });

            return response.Data.Customers;
        }

        public async Task<Customer> CreateCustomerAsync(string firstName, string lastName, string notes)
        {
            using var client = new GraphQLHttpClient("https://localhost:7028/graphql", new NewtonsoftJsonSerializer
            {
                JsonSerializerSettings = { ContractResolver = new CamelCasePropertyNamesContractResolver() }
            });

            var response = await client.SendQueryAsync<CreateCustomerResponse>(new GraphQL.GraphQLRequest
            {
                Query = @"
                    mutation createCustomer($firstName: String!, $lastName: String!, $notes: String!)
                    {
                      createCustomer(firstName: $firstName, lastName: $lastName, notes: $notes)
                      {
                        id, 
                        firstName,
                        lastName,
                        notes
                      }
                    }",
                OperationName = "createCustomer",
                Variables = new
                {
                    firstName,
                    lastName,
                    notes
                }
            });

            return response.Data.Customer;
        }

        private class OrdersResponse
        {
            public List<Order> Orders { get; set; }
        }

        private class CustomersResponse
        {
            public List<Customer> Customers { get; set; }
        }

        private class CreateCustomerResponse
        {
            [JsonProperty("createCustomer")]
            public Customer Customer { get; set; }
        }
    }
}
