using Newtonsoft.Json;

namespace Project_API.Entities.UserAggregate;
[JsonObject]
public record User_ID(Guid Value) : StronglyTypedId<Guid>(Value);


