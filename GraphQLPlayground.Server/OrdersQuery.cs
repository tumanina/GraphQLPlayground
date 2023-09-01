using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;
using GraphQLPlayground.Server.GraphTypes;
using GraphQLPlayground.Server.Models;
using GraphQLPlayground.Server.Repositories;

namespace GraphQLPlayground.Server
{
    public class OrdersQuery : ObjectGraphType
    {
        public OrdersQuery(IOrdersRepository ordersRepository, ICustomersRepository customersRepository)
        {
            AddField(new FieldType
            {
                Name = "customers",
                Type = typeof(ListGraphType<CustomerType>),
                Resolver = new FuncFieldResolver<ResolveFieldContext, List<Customer>>(async context =>
                {
                    return await customersRepository.GetAllCustomersAsync();
                })
            });
            AddField(new FieldType
            {
                Name = "customerById",
                Type = typeof(CustomerType),
                Arguments = new QueryArguments
                {
                    new QueryArgument<GuidGraphType> { Name = "id"}
                },
                Resolver = new FuncFieldResolver<ResolveFieldContext, Customer>(async context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    return await customersRepository.GetCustomerByIdAsync(id);
                })
            });
            AddField(new FieldType
            {
                Name = "customerByName",
                Type = typeof(ListGraphType<CustomerType>),
                Arguments = new QueryArguments
                {
                    new QueryArgument<StringGraphType> { Name = "name"}
                },
                Resolver = new FuncFieldResolver<ResolveFieldContext, List<Customer>>(async context =>
                {
                    var name = context.GetArgument<string>("name");
                    return await customersRepository.GetCustomersByNameAsync(name);
                })
            });
            AddField(new FieldType
            {
                Name = "orders",
                Type = typeof(ListGraphType<OrderType>),
                Resolver = new FuncFieldResolver<ResolveFieldContext, List<Order>>(async context =>
                {
                    return await ordersRepository.GetAllOrdersAsync();
                })
            });
            AddField(new FieldType
            {
                Name = "orderById",
                Type = typeof(OrderType),
                Arguments = new QueryArguments
                {
                    new QueryArgument<GuidGraphType> { Name = "id"}
                },
                Resolver = new FuncFieldResolver<ResolveFieldContext, Order>(async context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    return await ordersRepository.GetOrderByIdAsync(id);
                })
            });
        }
    }
}