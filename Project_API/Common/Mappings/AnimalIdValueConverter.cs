using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_API.Entities;
namespace Project_API.Common.Mappings;
public class AnimalIdValueConverter : ValueConverter<Animal_ID, Guid>
{
    public AnimalIdValueConverter() : base(
        id => id.Value,
        guid => new Animal_ID(guid)
    )
    { }
}
