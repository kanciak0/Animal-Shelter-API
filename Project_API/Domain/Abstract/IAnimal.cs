using Project_API.Entities.AnimalAggregate;

public interface IAnimal:IAnimalRepository
{
    Animal_ID Animal_UUID { get; }
    Animal.HealthCondition Condition { get; }
    string Name { get; }
    Species Species { get; }
}