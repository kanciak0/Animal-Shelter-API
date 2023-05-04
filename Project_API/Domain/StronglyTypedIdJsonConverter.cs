using Newtonsoft.Json;

namespace Project_API.Domain
{
    public class StronglyTypedIdJsonConverter<T> : JsonConverter<StronglyTypedId<T>> where T : class
    {
        public override StronglyTypedId<T>? ReadJson(JsonReader reader, Type objectType, StronglyTypedId<T>? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var guid = serializer.Deserialize<Guid>(reader);
            return new StronglyTypedId<T>(guid);
        }

        public override void WriteJson(JsonWriter writer, StronglyTypedId<T>? value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}