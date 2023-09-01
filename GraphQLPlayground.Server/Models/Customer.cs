using System.ComponentModel.DataAnnotations;

namespace GraphQLPlayground.Server.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Notes { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
