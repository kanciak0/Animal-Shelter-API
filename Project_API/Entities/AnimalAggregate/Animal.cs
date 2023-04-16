using Project_API.Entities.AnimalAggregate;
using System.Text.Json.Serialization;

public class Animal
{
    public Animal_ID Animal_UUID { get; private set; }
    public string Name { get; private set; }
    public Species Species { get; private set; }

    [JsonInclude]
    public HealthCondition Condition { get;private set; }

    private Animal() { }

    public static Animal CreateNewAnimal(string name, Species species,HealthCondition condition)
    {
        var animalId = new Animal_ID(Guid.NewGuid());
        var animal = new Animal { Animal_UUID = animalId, Name = name, Species = species,Condition = condition };
        return animal;
    }

    public class HealthCondition : Enumeration
    {
        public static HealthCondition Healthy = new("Healthy", nameof(Healthy));
        public static HealthCondition Sick = new("Sick", nameof(Sick));
        public HealthCondition(string condition, string conditionstatus) : base(condition, conditionstatus) { }
    }
}
