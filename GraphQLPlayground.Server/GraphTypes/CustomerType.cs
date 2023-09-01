using GraphQL.Types;
using GraphQLPlayground.Server.Models;

namespace GraphQLPlayground.Server.GraphTypes
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Name = "Customer";
            Description = "Customer Type";
            Field(d => d.Id, nullable: false).Description("Customer Id");
            Field(d => d.FirstName, nullable: false).Description("Customer FirstName");
            Field(d => d.LastName, nullable: false).Description("Customer LastName");
            Field(d => d.Notes, nullable: true).Description("Customer Notes");
            Field<ListGraphType<OrderType>>("orders");
        }
    }
}
