using Newtonsoft.Json;

namespace Project_API.Entities.Animal_ShelterAggregate;
[JsonObject]
public record AnimalShelter_ID(Guid Value) : StronglyTypedId<Guid>(Value);


