using Project_API.Entities.AnimalAggregate;

namespace Project_API.Entities.UserAggregate;

public class User_ID : StronglyTypedId<User_ID>
{
    public User_ID(Guid value) : base(value)
    {
    }
    public static User_ID FromGuid(Guid guid)
    {
        return new User_ID(guid);
    }
    public static User_ID NewId()
    {
        return new User_ID(Guid.NewGuid());
    }
}

