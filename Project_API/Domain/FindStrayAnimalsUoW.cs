using Project_API.Common.Mappings;
using Project_API.Domain.Abstract;
using Project_API.Domain.Animal_ShelterAggregate;
using Project_API.Entities.Animal_ShelterAggregate;
using Project_API.Features._AnimalShelter;

namespace Project_API.Domain
{
    public class FindStrayAnimalsUoW : IFindStrayAnimalsUoW
    {
        private readonly IAnimalShelterRepository _animalShelterRepository;
        private readonly IAnimalRepository _animalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FindStrayAnimalsUoW(IAnimalShelterRepository animalShelterRepository, IAnimalRepository animalRepository, IUnitOfWork unitOfWork)
        {
            _animalRepository = animalRepository;
            _animalShelterRepository = animalShelterRepository;
            _unitOfWork = unitOfWork;
        }
        public void DoWork(FindStrayAnimalCommand request)
        {
            var shelter = _animalShelterRepository.GetByID(request.AnimalShelter_ID);
            var animal = _animalRepository.GetByID(request.Animal_ID);
            var shelteredAnimal = ShelteredAnimalMapping.ToShelteredAnimal(animal,shelter.AnimalShelter_ID);

            shelter.RegisterShelteredAnimal(shelteredAnimal.ShelteredAnimal_UUID,shelteredAnimal.Name, shelteredAnimal.Species,shelter.AnimalShelter_ID);
            _animalRepository.Delete(animal.Animal_UUID);

            _animalShelterRepository.Update(shelter);

            _unitOfWork.SaveChangesAsync();
        }
    }
}
