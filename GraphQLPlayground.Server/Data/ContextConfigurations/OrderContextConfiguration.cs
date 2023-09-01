using GraphQLPlayground.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQLPlayground.Server.Data.ContextConfigurations
{
    public class OrderContextConfiguration : IEntityTypeConfiguration<Order>
    {
        private Guid[] _ids;

        public OrderContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(
                new Order
                {
                    Id = Guid.NewGuid(),
                    Status = "Placed",
                    CreaatedAt = DateTime.UtcNow.AddDays(-1),
                    CustomerId = _ids[0]
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Status = "Shipped",
                    CreaatedAt = DateTime.UtcNow.AddDays(-2),
                    CustomerId = _ids[0]
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Status = "Delivered",
                    CreaatedAt = DateTime.UtcNow.AddDays(-3),
                    CustomerId = _ids[0]
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Status = "Placed.",
                    CreaatedAt = DateTime.UtcNow.AddDays(-1),
                    CustomerId = _ids[1]
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Status = "Delivered",
                    CreaatedAt = DateTime.UtcNow.AddDays(-1),
                    CustomerId = _ids[2]
                }
            );
        }
    }
}