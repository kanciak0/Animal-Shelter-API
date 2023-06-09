﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Project_API.Entities.AnimalAggregate;
using static Animal;

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

        builder.OwnsOne(a => a.Species)
            .Property(a => a.Breed)
             .HasColumnName("Breed")
             .HasMaxLength(50)
             .IsRequired();

        builder.Property(x => x.Condition)
               .HasConversion(
                v => v.ToString(),
                v => (HealthCondition)Enum
                .Parse(typeof(HealthCondition), v));
    }
}
