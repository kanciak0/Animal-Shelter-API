namespace Project_API.Entities.UserAggregate;

public record User_ID(Guid Value) : StronglyTypedId<Guid>(Value);


