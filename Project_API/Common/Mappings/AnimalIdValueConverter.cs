using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_API.Entities;

public class AnimalIdValueConverter : ValueConverter<Animal_ID, Guid>
{
    public AnimalIdValueConverter() : base(
        id => id.Value,
        guid => new Animal_ID(guid)
    )
    { }
}
