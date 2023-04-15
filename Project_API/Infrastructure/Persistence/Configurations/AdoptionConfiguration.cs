using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_API.Common.Mappings;
using Project_API.Entities.Animal_ShelterAggregate;

namespace Project_API.Infrastructure.Persistence.Configurations
{
    public class AdoptionConfiguration : IEntityTypeConfiguration<Adoption>
    {
        public void Configure(EntityTypeBuilder<Adoption> builder)
        {
            builder.ToTable("Adoption");

            builder.HasKey(x => x.Id);
                builder.Property(x => x.Id)
               .ValueGeneratedOnAdd()
               .UseIdentityColumn()
               .HasColumnName("AdoptionID");

            builder.Property(p => p.Client_ids)
            .HasConversion(new CollectionToStringConverter<Client_ID>())
               .HasColumnName("Client_IDs");

            builder.Property(x => x.ShelteredAnimal_ids)
            .HasConversion(new CollectionToStringConverter<ShelteredAnimal_ID>())
               .HasColumnName("ShelteredAnimal_IDs");
        }
    }
}


