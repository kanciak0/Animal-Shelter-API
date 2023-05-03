using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_API.Entities.Animal_ShelterAggregate;

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
                id => id.ToString(),
                str => Client_ID.FromGuid(Guid.Parse(str)))
                .HasColumnName("Client_ID");

            builder.Property(x => x.ShelteredAnimal_id)
                .HasConversion(id => id.ToString(),
                str => ShelteredAnimal_ID.FromGuid(Guid.Parse(str)))
                .HasColumnName("ShelteredAnimal_IDs");

            builder.Property(x => x.animal_shelter_Id)
                .HasConversion(
                 id => id.ToString(),
                 str => AnimalShelter_ID.FromGuid(Guid.Parse(str)))
            .HasColumnName("AnimalShelter_ID");
        }
    }
}


