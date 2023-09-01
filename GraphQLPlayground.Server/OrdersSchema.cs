using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLPlayground.Server
{
    public class OrdersSchema : Schema
    {
        public OrdersSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<OrdersQuery>();
            Mutation = serviceProvider.GetRequiredService<OrderMutation>();
        }
    }
}
