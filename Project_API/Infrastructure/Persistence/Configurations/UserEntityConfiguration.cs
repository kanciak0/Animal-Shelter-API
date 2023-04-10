using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_API.Common.Mappings;
using Project_API.Entities;
using System.Reflection.Emit;

namespace Project_API.Infrastructure.Persistence.Configurations
{
    public class UserEntityConfiguration: IEntityTypeConfiguration<User_Entity>
    {
        public void Configure(EntityTypeBuilder<User_Entity> builder) 
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.User_UUID);
            builder.Property(u => u.User_UUID)
            .HasColumnName("User_UUID")
            .IsRequired()
            .HasConversion(userId => userId.Value,
            value =>new User_ID(value));
            builder.OwnsOne(p => p.Address)
                            .Property(p => p.City).HasColumnName("City");

            builder.OwnsOne(p => p.Address)
                                        .Property(p => p.State).HasColumnName("State");
            builder.OwnsOne(p => p.Address)
                                        .Property(p => p.Country).HasColumnName("Country");
            builder.OwnsOne(p => p.Credentials)
                                        .Property(p => p.FirstName).HasColumnName("Firstname");
            builder.OwnsOne(p => p.Credentials)
                                        .Property(p => p.LastName).HasColumnName("Lastname");
            
        }
        
    }
}
