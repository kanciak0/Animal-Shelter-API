using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Project_API.Entities.Animal_ShelterAggregate;
using Project_API.Entities.AnimalAggregate;
using Project_API.Entities.UserAggregate;

namespace Project_API.Infrastructure.Persistence.Configurations
{
    public class UserAnimalsEntityConfiguration : IEntityTypeConfiguration<UserAnimals>
    {
        public void Configure(EntityTypeBuilder<UserAnimals> builder)
        {
            builder.Ignore(a => a.User);
            builder.Ignore(u => u.user_id);
            builder.ToTable("UserAnimals");
            builder.HasKey(a => a.AnimalId);

            builder.Property(a => a.AnimalId)
                .HasColumnName("Animal_ID")
                .IsRequired()
                .HasConversion(animalid => animalid.Value,
                value => new UserAnimalId(value));

        }
    }
}
