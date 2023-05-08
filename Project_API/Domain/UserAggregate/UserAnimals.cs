using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project_API.Entities.UserAggregate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserAnimals
{
    private UserAnimals() { }
    public UserAnimals(UserAnimalId animalId, string name)
    {
        AnimalId = animalId;
        Name = name;
    }
    public User_ID user_id { get; }

    public UserAnimalId AnimalId { get; private set; }
    public string Name { get; private set; }
    public User User { get; }
}
public record UserAnimalId(Guid Value) : StronglyTypedId<Guid>(Value);