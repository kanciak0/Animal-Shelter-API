using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_API.Entities.UserAggregate;

namespace Project_API.Infrastructure.Persistence.Configurations
{
    public class UserAnimalsIDConfiguration: IEntityTypeConfiguration<UserAnimalsID>
    {
        public void Configure(EntityTypeBuilder<UserAnimalsID> builder)
        {
            builder.ToTable("UserAnimalsIDs");
            builder.HasKey(e => e.Value);

            builder.Property(e => e.Value)
                .HasColumnName("Value")
                .IsRequired();
            
        }
    }
}
