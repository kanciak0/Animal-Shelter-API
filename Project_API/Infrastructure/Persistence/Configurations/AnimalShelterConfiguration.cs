using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_API.Entities.Animal_ShelterAggregate;

namespace Project_API.Infrastructure.Persistence.Configurations
{
    public class AnimalShelterConfiguration:IEntityTypeConfiguration<AnimalShelter>
    {
        public void Configure(EntityTypeBuilder<AnimalShelter> builder)
        {
            builder.HasKey(a => a.AnimalShelter_ID);

            builder.Property(a => a.AnimalShelter_ID)
                .HasColumnName("AnimalShelter_ID")
                .IsRequired()
                .HasConversion
                (shelterid => shelterid.Value,
                value => new AnimalShelter_ID(value));

            builder.HasMany(a => a.shelteredanimals)
                .WithOne(sa => sa.AnimalShelter)
                .HasForeignKey(sa => sa.animal_shelter_Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.clients)
                .WithOne(c => c.AnimalShelter)
                .HasForeignKey(c => c.animal_shelter_Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.adoptions)
                .WithOne(ad => ad.AnimalShelter)
                .HasForeignKey(ad => ad.animal_shelter_Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
