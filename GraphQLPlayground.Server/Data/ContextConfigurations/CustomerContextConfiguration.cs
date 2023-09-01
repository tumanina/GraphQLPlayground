using GraphQLPlayground.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQLPlayground.Server.Data.ContextConfigurations
{
    public class CustomerContextConfiguration : IEntityTypeConfiguration<Customer>
    {
        private Guid[] _ids;

        public CustomerContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer
                {
                    Id = _ids[0],
                    FirstName = "Jane",
                    LastName = "Doe",
                    Notes = "Customer Jane Doe"
                },
                new Customer
                {
                    Id = _ids[1],
                    FirstName = "John",
                    LastName = "Doe",
                    Notes = "Customer John Doe"
                },
                new Customer
                {
                    Id = _ids[2],
                    FirstName = "James",
                    LastName = "Smith",
                    Notes = "Customer James Smith"
                });
        }
    }
}
