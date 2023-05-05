using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_API.Entities.Animal_ShelterAggregate;
using static Project_API.Entities.Animal_ShelterAggregate.Client;

public class ClientEntityConfiguration:IEntityTypeConfiguration<Client>
    {
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.Ignore(a => a.animal_shelter_Id);
        builder.Ignore(a => a.AnimalShelter);

        builder.ToTable("Clients");

        builder.HasKey(c => c.Client_UUID);

        builder.Property(c => c.Client_UUID)
            .HasColumnName("Client_ID")
            .IsRequired()
            .HasConversion(clientId => clientId.Value,
            value => new Client_ID(value));

        builder.OwnsOne(c => c.Address)
            .Property(c => c.ZipCode).
            HasColumnName("ZipCode");
            

        builder.OwnsOne(c => c.Address)
            .Property(c => c.Street)
            .HasMaxLength(255)
            .HasColumnName("Street");

        builder.OwnsOne(c => c.Address)
            .Property(c => c.HouseNumber).
            HasColumnName("HouseNumber");

        builder.OwnsOne(c => c.Credentials)
            .Property(c => c.FirstName)
            .HasMaxLength(255)
            .HasColumnName("FirstName");

        builder.OwnsOne(c => c.Credentials)
            .Property(c => c.LastName)
            .HasMaxLength(255)
            .HasColumnName("LastName");

        builder.Property(x => x._Responsibility)
           .HasConversion(
            v => v.ToString(),
            v => (Responsibility)Enum
            .Parse(typeof(Responsibility), v));

    }
}
