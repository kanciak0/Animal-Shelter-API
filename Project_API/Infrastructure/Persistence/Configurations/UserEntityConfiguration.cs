using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_API.Entities;

namespace Project_API.Infrastructure.Persistence.Configurations
{
    public class UserEntityConfiguration: IEntityTypeConfiguration<User_entity>
    {
        public void Configure(EntityTypeBuilder<User_entity> builder) 
        {
            builder.OwnsOne(p => p.Address)
                            .Property(p => p.City).HasColumnName("City");

            builder.OwnsOne(p => p.Address)
                                        .Property(p => p.State).HasColumnName("State");
            builder.OwnsOne(p => p.Address)
                                        .Property(p => p.Country).HasColumnName("Country");
        }
    }
}
