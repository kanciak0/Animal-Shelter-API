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
            var shelter = _animalShelterRepository.GetByID(request.AnimalShelter_ID.ToGuid());
            var animal = _animalRepository.GetByID(request.Animal_ID.ToGuid());
            var shelteredAnimal = ShelteredAnimalMapping.ToShelteredAnimal(animal);

            shelter.RegisterShelteredAnimal(shelteredAnimal.ShelteredAnimal_UUID, request.AnimalName, shelteredAnimal.Species);
            _animalRepository.Delete(request.Animal_ID.ToGuid());

            _animalRepository.Update(animal);
            _animalShelterRepository.Update(shelter);

            _unitOfWork.SaveChangesAsync();
            _unitOfWork.Dispose();
        }
    }
}
