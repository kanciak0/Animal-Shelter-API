using Newtonsoft.Json;

namespace Project_API.Entities.Animal_ShelterAggregate;
[JsonObject]
public record Client_ID(Guid Value) : StronglyTypedId<Guid>(Value);

