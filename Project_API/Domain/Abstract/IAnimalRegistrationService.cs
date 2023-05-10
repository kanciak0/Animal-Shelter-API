using Project_API.Entities.Animal_ShelterAggregate;

namespace Project_API.Domain.Abstract
{
    public interface IAnimalRegistrationService
    {
        ShelteredAnimal RegisterShelteredAnimal(ShelteredAnimal_ID id, string name, ShelteredAnimalSpecies species, AnimalShelter_ID animalShelter_ID);
    }
}
