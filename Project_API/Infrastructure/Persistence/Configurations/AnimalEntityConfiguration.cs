using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Project_API.Entities;

public class AnimalEntityConfiguration : IEntityTypeConfiguration<Animal_Entity>
{
    public void Configure(EntityTypeBuilder<Animal_Entity> builder)
    {
        builder.ToTable("Animals");
        builder.Ignore(u => u.User);
        builder.HasKey(a => a.Animal_UUID);

        builder.Property(a => a.Animal_UUID)
            .HasColumnName("Animal_UUID")
            .IsRequired()
            .HasConversion(animalid => animalid.Value,
            value =>new Animal_ID(value));

        builder.Property(a => a.Name)
            .HasColumnName("Name")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(a => a.Species)
            .HasColumnName("Species")
            .HasMaxLength(50)
            .IsRequired();

        builder.HasOne<User_Entity>()
            .WithMany(u => u.Animals)
            .HasForeignKey("User_UUID")
            .OnDelete(DeleteBehavior.SetNull) 
            .IsRequired(false);
    }
}
