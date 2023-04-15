using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_API.Entities.Animal_ShelterAggregate;
using System.Text.Json;

namespace Project_API.Common.Mappings
{
    public class ValueConverters : ValueConverter<ICollection<string>, string>
    {
        public ValueConverters()
            : base(
                v => string.Join(",", v),
                v => v.Split(",", StringSplitOptions.None).ToList())
        { }
    }
    public class CollectionToStringConverter<T> : ValueConverter<ICollection<T>, string>
    {
        private static readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public CollectionToStringConverter() : base(
            collection => JsonSerializer.Serialize(collection, _jsonSerializerOptions),
            json => JsonSerializer.Deserialize<ICollection<T>>(json, _jsonSerializerOptions) ?? new List<T>())
        { }
    }
}
