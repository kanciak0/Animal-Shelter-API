using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_API.Entities.Animal_ShelterAggregate;
using static Enumeration;
using static Project_API.Entities.Animal_ShelterAggregate.ShelteredAnimal;
using static Project_API.Entities.Animal_ShelterAggregate.ShelteredAnimal.HealthCondition;

namespace Project_API.Infrastructure.Persistence.Configurations
{
    public class ShelteredAnimalEntityConfiguration:IEntityTypeConfiguration<ShelteredAnimal>
    {
        public void Configure(EntityTypeBuilder<ShelteredAnimal> builder)
        {
            builder.ToTable("ShelteredAnimal");
            builder.HasKey(a => a.ShelteredAnimal_UUID);

            builder.Property(a =>a.ShelteredAnimal_UUID)
            .HasColumnName("ShelteredAnimal_UUID")
            .IsRequired()
            .HasConversion(animalId => animalId.Value,
            value => new ShelteredAnimal_ID(value));

            builder.OwnsOne(a => a.Species)
                .Property(a => a._ShelteredAnimalSpecies)
                .HasMaxLength(255)
                .HasColumnName("ShelteredAnimalSpecies");

            builder.Property(a => a.Name)
                .HasColumnName("Name")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Condition)
                .IsRequired()
                .HasConversion(new EnumerationValueConverter<HealthCondition>());
        }
    }
}
