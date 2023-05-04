using System.Text.Json.Serialization;
using System.Text.Json;

namespace Project_API.Domain
{
    public class StronglyTypedIdJsonConverter<T> : JsonConverter<StronglyTypedId<T>> where T : class
    {
        public override StronglyTypedId<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string idString = reader.GetString();

            Guid idGuid;
            if (!Guid.TryParse(idString, out idGuid))
            {
                throw new JsonException($"Invalid Guid value '{idString}' in JSON.");
            }
            return new StronglyTypedId<T>(idGuid);
        }


        public override void Write(Utf8JsonWriter writer, StronglyTypedId<T> value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
