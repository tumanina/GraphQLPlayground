namespace GraphQLPlayground.Client.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public string Status { get; set; }

        public Customer Customer { get; set; }
    }
}
