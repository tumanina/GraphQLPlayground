using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GraphQLPlayground.Server.Data
{
    public class OrdersDbContextFactory : IDesignTimeDbContextFactory<OrdersDbContext>
    {
        public OrdersDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrdersDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=order_db;Persist Security Info=true;Integrated Security=SSPI;Encrypt=false");


            return new OrdersDbContext(optionsBuilder.Options);
        }
    }
}
