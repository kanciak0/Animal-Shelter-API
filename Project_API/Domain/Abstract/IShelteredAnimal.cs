using Project_API.Domain.Animal_ShelterAggregate;
using Project_API.Entities.Animal_ShelterAggregate;

namespace Project_API.Domain.Abstract
{
    public interface IShelteredAnimal
    {
        ShelteredAnimal.HealthCondition Condition { get; }
        string Name { get; }
        ShelteredAnimal_ID ShelteredAnimal_UUID { get; }
        ShelteredAnimalSpecies Species { get; }
        ShelteredAnimal.AdoptionStatus Status { get; }

        void SetAdoptionStatus(ShelteredAnimal.AdoptionStatus status);
        void SetCondition(ShelteredAnimal.HealthCondition condition);
    }
}