using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_API.Entities.Animal_ShelterAggregate;
using Project_API.Entities.AnimalAggregate;

namespace Project_API.Infrastructure.Persistence.Configurations
{
    public class AdoptionConfiguration : IEntityTypeConfiguration<Adoption>
    {
        public void Configure(EntityTypeBuilder<Adoption> builder)
        {
            builder.Ignore(a => a.animal_shelter_Id);
            builder.Ignore(a => a.AnimalShelter);

            builder.ToTable("Adoption");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
           .ValueGeneratedOnAdd()
           .UseIdentityColumn()
           .HasColumnName("AdoptionID");

            builder.Property(p => p.Client_id)
                .HasConversion(
                clientid => clientid.Value,
                value => new Client_ID(value))
                .HasColumnName("Client_id");
  
            builder.Property(x => x.ShelteredAnimal_id)
                .HasConversion(
                shelteredanimalid => shelteredanimalid.Value,
                value => new ShelteredAnimal_ID(value))
                .HasColumnName("ShelteredAnimal_id");

            builder.Property(x => x.animal_shelter_Id)
                .HasConversion(animashelterlid => animashelterlid.Value,
                value => new AnimalShelter_ID(value))
                .HasColumnName("AnimalShelter_id");
        }
    }
}


