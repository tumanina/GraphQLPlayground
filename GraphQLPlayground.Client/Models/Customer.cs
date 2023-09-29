using System.ComponentModel.DataAnnotations;

namespace GraphQLPlayground.Client.Models
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Notes { get; set; }

        public List<Order> Orders { get; set; }
    }
}
