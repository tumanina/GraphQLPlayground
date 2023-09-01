using GraphQLPlayground.Server.Data.ContextConfigurations;
using GraphQLPlayground.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLPlayground.Server.Data
{
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var ids = new Guid[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };

            builder.ApplyConfiguration(new CustomerContextConfiguration(ids));
            builder.ApplyConfiguration(new OrderContextConfiguration(ids));
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
