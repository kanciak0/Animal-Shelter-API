using Project_API.Entities.AnimalAggregate;
using System.Text.Json.Serialization;

public class Animal
{
    public Animal(Animal_ID animal_UUID, string name, Species species, HealthCondition condition)
    {
        Animal_UUID = animal_UUID;
        Name = name;
        Species = species;
        Condition = condition;
    }

    public Animal() { }
    public Animal_ID Animal_UUID { get; private set; }
    public string Name { get; private set; }
    public Species Species { get; private set; }
    public HealthCondition Condition { get; private set; }
    public enum HealthCondition
    {
        Sick,
        Healthy
    }
    public static Animal CreateAnimal(Animal_ID uuid, string name, Species species)
    {
        return new Animal { Animal_UUID = uuid, Species = species, Name = name };
    }
    /*
    public class HealthCondition : Enumeration
    {
        public static HealthCondition Healthy = new("Healthy", nameof(Healthy));
        public static HealthCondition Sick = new("Sick", nameof(Sick));
        public HealthCondition(string condition, string conditionstatus) : base(condition, conditionstatus) { }
    }*/
}
