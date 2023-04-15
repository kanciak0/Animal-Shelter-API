using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_API.Entities.AnimalAggregate;

namespace Project_API.Common.Mappings;
// TODO: Make it generic

public class AnimalIdValueConverter : ValueConverter<Animal_ID, Guid>
{
    public AnimalIdValueConverter() : base(
        id => id.Value,
        guid => new Animal_ID(guid)
    )
    { }
}