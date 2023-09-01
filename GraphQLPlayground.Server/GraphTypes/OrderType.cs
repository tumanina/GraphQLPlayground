using GraphQL.Types;
using GraphQLPlayground.Server.Models;

namespace GraphQLPlayground.Server.GraphTypes
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType()
        {
            Name = "Order";
            Description = "Order Type";
            Field(d => d.Id, nullable: false).Description("Order Id");
            Field(d => d.Status, nullable: false).Description("Order Status");
            Field(d => d.CreaatedAt, nullable: false).Description("Order CreatedAt");
            Field<CustomerType>("customer");
        }
    }
}
