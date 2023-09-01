using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;
using GraphQLPlayground.Server.GraphTypes;
using GraphQLPlayground.Server.Models;
using GraphQLPlayground.Server.Repositories;

namespace GraphQLPlayground.Server
{
    public class OrderMutation : ObjectGraphType
    {
        public OrderMutation(ICustomersRepository customersRepository)
        {
            AddField(new FieldType
            {
                Name = "createCustomer",
                Type = typeof(CustomerType),
                Arguments = new QueryArguments
                {
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "firstName" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "lastName" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "notes" }
                },
                Resolver = new FuncFieldResolver<ResolveFieldContext, Customer>(async context =>
                {
                    var firstName = context.GetArgument<string>("firstName");
                    var lastName = context.GetArgument<string>("lastName");
                    var notes = context.GetArgument<string>("notes");
                    return await customersRepository.CreateCustomerAsync(new Customer
                    {
                        Id = Guid.NewGuid(),
                        FirstName = firstName,
                        LastName = lastName,
                        Notes = notes
                    });
                })
            });
        }
    }
}