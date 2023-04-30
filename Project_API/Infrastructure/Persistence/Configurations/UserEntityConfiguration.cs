using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_API.Common.Mappings;
using Project_API.Entities;
using Project_API.Entities.UserAggregate;
using System.Reflection.Emit;
using static Enumeration;
using static Project_API.Entities.UserAggregate.User;

namespace Project_API.Infrastructure.Persistence.Configurations
{
    public class UserEntityConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder) 
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.User_UUID);
            builder.Property(u => u.User_UUID)
            .HasColumnName("User_UUID")
            .IsRequired()
            .HasConversion(userId => userId.ToGuid(),
            value =>new User_ID(value));


            builder.OwnsOne(p => p.UserAddress)
                .Property(p => p.City)
                .HasMaxLength(255)
                .HasColumnName("City");

            builder.OwnsOne(p => p.UserAddress)
                .Property(p => p.State)
                .HasMaxLength(255)
                .HasColumnName("State");

            builder.OwnsOne(p => p.UserAddress)
                .Property(p => p.Country)
                .HasMaxLength(255)
                .HasColumnName("Country");

            builder.OwnsOne(p => p.UserCredentials)
                .Property(p => p.FirstName)
                .HasMaxLength(255)
                .HasColumnName("Firstname");

            builder.OwnsOne(p => p.UserCredentials)
                .Property(p => p.LastName)
                .HasMaxLength(255)
                .HasColumnName("Lastname");
            builder.HasMany(u => u.AnimalIds)
            .WithOne()
            .HasForeignKey(a => a.UserID)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }  
}
