using Project_API.Entities.UserAggregate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserAnimalsID : StronglyTypedId<UserAnimalsID>
{
    [Key]
    public User_ID Animal_ID { get; private set; }

    [NotMapped]
    public User User { get; }
    public UserAnimalsID(Guid value) : base(value)
    {
        Animal_ID = User_ID.FromGuid(value);
    }

    public UserAnimalsID() : base(Guid.NewGuid())
    {
    }

    public static UserAnimalsID FromGuid(Guid guid)
    {
        return new UserAnimalsID(guid);
    }
}
