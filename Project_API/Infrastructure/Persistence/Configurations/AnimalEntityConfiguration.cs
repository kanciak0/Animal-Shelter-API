using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Project_API.Entities.AnimalAggregate;
using Project_API.Entities.UserAggregate;
using static Project_API.Entities.Animal_ShelterAggregate.ShelteredAnimal.HealthCondition;
using static Enumeration;
using static Project_API.Entities.AnimalAggregate.Animal;

public class AnimalEntityConfiguration : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> builder)
    {
        builder.ToTable("Animals");
        builder.HasKey(a => a.Animal_UUID);

        builder.Property(a => a.Animal_UUID)
            .HasColumnName("Animal_UUID")
            .IsRequired()
            .HasConversion(animalid => animalid.Value,
            value => new Animal_ID(value));

        builder.Property(a => a.Name)
            .HasColumnName("Name")
            .HasMaxLength(50)
            .IsRequired();

        builder.OwnsOne(a => a.Species).Property(a => a._Species)
            .HasColumnName("Species")
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(x => x.Condition).
            IsRequired()
            .HasConversion(new EnumerationValueConverter<HealthCondition>());
    }
}
