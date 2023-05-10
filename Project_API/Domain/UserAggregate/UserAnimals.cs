using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project_API.Domain.UserAggregate;
using Project_API.Entities.UserAggregate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserAnimals
{
    public UserAnimals() { }
    public UserAnimals(UserAnimalId animalId, string name,UserAnimalSpecies userAnimalSpecies, UserAnimalHealthCondition condition)
    {
        AnimalId = animalId;
        Name = name;
        Species = userAnimalSpecies;
        Condition = condition;
    }
    
    public UserAnimalId AnimalId { get; private set; }
    public string Name { get; private set; }
    public UserAnimalSpecies Species { get; private set; }
    public UserAnimalHealthCondition Condition { get; private set; }
    public enum UserAnimalHealthCondition
    {
        Sick,
        Healthy
    }
    public User User { get; }
    public User_ID user_id { get; }
}
[JsonObject]
public record UserAnimalId(Guid Value) : StronglyTypedId<Guid>(Value);