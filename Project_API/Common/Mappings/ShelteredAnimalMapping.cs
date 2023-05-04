using Project_API.Domain.Abstract;
using Project_API.Entities.Animal_ShelterAggregate;
using Project_API.Entities.UserAggregate;

namespace Project_API.Common.Mappings
{
    public static class ShelteredAnimalMapping
    {
        public static ShelteredAnimal CreateShelteredAnimal(Animal animal, IAnimalRegistrationService animalRegistrationService)
        {
            var shelteredAnimalId = new ShelteredAnimal_ID(animal.Animal_UUID.ToGuid());
            var shelteredAnimalSpecies = new ShelteredAnimalSpecies(animal.Species.Breed);
            var healthCondition = animal.Condition switch
            {
                Animal.HealthCondition.Healthy => ShelteredAnimal.HealthCondition.Healthy,
                Animal.HealthCondition.Sick => ShelteredAnimal.HealthCondition.Sick,
                _ => throw new ArgumentOutOfRangeException(nameof(animal.Condition), animal.Condition, "Unknown health condition value")
            };
            var shelteredAnimal = new ShelteredAnimal(shelteredAnimalId, animal.Name, shelteredAnimalSpecies);
            shelteredAnimal.SetCondition(healthCondition);
            return animalRegistrationService.RegisterShelteredAnimal(shelteredAnimalId, animal.Name, shelteredAnimalSpecies);
        }
        public static ShelteredAnimal_ID MapToShelteredAnimalId(UserAnimalsID userAnimalsId)
        {
            return new ShelteredAnimal_ID(userAnimalsId.ToGuid());
        }
        /* #TODO: make it work :)
            public static Animal CreateAnimal(ShelteredAnimal shelteredAnimal, IAnimalRegistrationService animalRegistrationService)
            {
                var animalId = new Animal_ID(shelteredAnimal.ShelteredAnimal_UUID.ToGuid());
                var animalSpecies = new AnimalSpecies(shelteredAnimal.Species._Species);
                var healthCondition = shelteredAnimal.Condition switch
                {
                    ShelteredAnimal.HealthCondition.Healthy => Animal.HealthCondition.Healthy,
                    ShelteredAnimal.HealthCondition.Sick => Animal.HealthCondition.Sick,
                    _ => throw new ArgumentOutOfRangeException(nameof(shelteredAnimal.Condition), shelteredAnimal.Condition, "Unknown health condition value")
                };
                var animal = new Animal(animalId, shelteredAnimal.Name, animalSpecies, healthCondition);
                return animalRegistrationService.RegisterAnimal(animal);
            }*/
    }
}

