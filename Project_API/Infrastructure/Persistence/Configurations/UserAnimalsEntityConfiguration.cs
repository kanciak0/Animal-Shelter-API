using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Project_API.Entities.Animal_ShelterAggregate;
using Project_API.Entities.AnimalAggregate;
using Project_API.Entities.UserAggregate;
using Project_API.DTO;

namespace Project_API.Infrastructure.Persistence.Configurations
{
    public class UserAnimalsEntityConfiguration : IEntityTypeConfiguration<UserAnimals>
    {
        public void Configure(EntityTypeBuilder<UserAnimals> builder)
        {
            builder.Ignore(a => a.User);
            builder.Ignore(u => u.User_id);
            builder.ToTable("UserAnimals");
            builder.HasKey(c => c.AnimalId);

            builder.HasOne(a => a.User)
               .WithMany(a => a.Animals)
               .HasForeignKey(a => a.User_id);

            builder.Property(a => a.AnimalId)
                .HasColumnName("Animal_ID")
                .IsRequired()
                .HasConversion(animalid => animalid.Value,
                value => new UserAnimalId(value));

            builder.OwnsOne(a => a.Species)
            .Property(a => a.Breed)
             .HasColumnName("Breed")
             .HasMaxLength(50)
             .IsRequired();

            builder.Property(x => x.Condition)
                   .HasConversion(
                    v => v.ToString(),
                    v => (UserAnimals.UserAnimalHealthCondition)(HealthCondition)Enum
                    .Parse(typeof(HealthCondition), v));
        }
    }
}
