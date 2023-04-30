namespace Project_API.Entities.UserAggregate;

public class UserAnimalsID : StronglyTypedId<UserAnimalsID>
{
    public User_ID UserID { get; }
    public UserAnimalsID(Guid value) : base(value)
    {
    }
    public static UserAnimalsID FromGuid(Guid guid)
    {
        return new UserAnimalsID(guid);
    }
}

