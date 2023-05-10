using Project_API.Domain.Abstract;
using Project_API.Domain.UserAggregate;
using Project_API.Entities.Animal_ShelterAggregate;
using Project_API.Entities.UserAggregate;

namespace Project_API.Common.Mappings
{
    public static class ShelteredAnimalMapping
    {
        public static ShelteredAnimal CreateShelteredAnimalFromUserpet(Animal animal, IAnimalRegistrationService animalRegistrationService
            ,AnimalShelter_ID animalShelter_ID)
        {
            var shelteredAnimalId = new ShelteredAnimal_ID(animal.Animal_UUID.Value);
            var shelteredAnimalSpecies = new ShelteredAnimalSpecies(animal.Species.Breed);
            var healthCondition = animal.Condition switch
            {
                Animal.HealthCondition.Healthy => ShelteredAnimal.HealthCondition.Healthy,
                Animal.HealthCondition.Sick => ShelteredAnimal.HealthCondition.Sick,
                _ => throw new ArgumentOutOfRangeException(nameof(animal.Condition), animal.Condition, "Unknown health condition value")
            };
            var shelteredAnimal = new ShelteredAnimal(shelteredAnimalId, animal.Name, shelteredAnimalSpecies, animalShelter_ID);
            shelteredAnimal.SetCondition(healthCondition);
            return animalRegistrationService.RegisterShelteredAnimal(shelteredAnimalId, animal.Name, shelteredAnimalSpecies, animalShelter_ID);
        }
        public static ShelteredAnimal_ID MapToShelteredAnimalId(UserAnimalId userAnimalsId)
        {
            return new ShelteredAnimal_ID(userAnimalsId.Value);
        }
        public static ShelteredAnimal ToShelteredAnimal(Animal animal,AnimalShelter_ID animalShelter_ID)
        {
            var shelteredAnimal = new ShelteredAnimal(
                new ShelteredAnimal_ID(animal.Animal_UUID.Value),
                animal.Name,
                new ShelteredAnimalSpecies(animal.Species.Breed)
                , animalShelter_ID
            );
            shelteredAnimal.SetCondition(animal.Condition == Animal.HealthCondition.Sick ?
                ShelteredAnimal.HealthCondition.Sick : ShelteredAnimal.HealthCondition.Healthy);
            shelteredAnimal.SetAdoptionStatus(ShelteredAnimal.AdoptionStatus.NotAdopted);
            return shelteredAnimal;
        }

            public static UserAnimals ToUserAnimal(ShelteredAnimal shelteredAnimal)
            {
                var animalId = new UserAnimalId(shelteredAnimal.ShelteredAnimal_UUID.Value);
                var animalSpecies = new UserAnimalSpecies(shelteredAnimal.Species.Breed);
                var healthCondition = shelteredAnimal.Condition switch
                {
                    ShelteredAnimal.HealthCondition.Healthy => UserAnimals.UserAnimalHealthCondition.Healthy,
                    ShelteredAnimal.HealthCondition.Sick => UserAnimals.UserAnimalHealthCondition.Sick,
                    _ => throw new ArgumentOutOfRangeException(nameof(shelteredAnimal.Condition), shelteredAnimal.Condition, "Unknown health condition value")
                };
                var useranimal = new UserAnimals(animalId, shelteredAnimal.Name, animalSpecies, healthCondition);
            return useranimal;
            }
    }
}

