using System.ComponentModel.DataAnnotations;

namespace GraphQLPlayground.Server.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreaatedAt { get; set; }
        public string Status { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
