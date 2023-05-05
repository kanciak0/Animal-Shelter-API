using Newtonsoft.Json;

namespace Project_API.Entities.Animal_ShelterAggregate;

public record ShelteredAnimal_ID(Guid Value) : StronglyTypedId<Guid>(Value);