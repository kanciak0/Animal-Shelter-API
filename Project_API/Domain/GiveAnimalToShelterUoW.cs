using Project_API.Common.Mappings;
using Project_API.Domain.Abstract;
using Project_API.Domain.Animal_ShelterAggregate;
using Project_API.Entities.Animal_ShelterAggregate;
using Project_API.Entities.UserAggregate;
using Project_API.Features._AnimalShelter;

namespace Project_API.Domain
{
    public class GiveAnimalToShelterUoW : IGiveAnimalToShelterUoW
    {
        private readonly IUserRepository _userRepository;
        private readonly IAnimalShelterRepository _animalShelterRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GiveAnimalToShelterUoW(IUserRepository userRepository, IAnimalShelterRepository animalShelterRepository, IUnitOfWork unitOfWork)
        {
            _animalShelterRepository = animalShelterRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public void DoWork(GiveAnimalFromClientToShelterCommand request)
        {
            var user = _userRepository.GetByID(request.User_ID);
            var shelter = _animalShelterRepository.GetByID(request.AnimalShelter_ID);
            var animalIdToRemove = request.UserAnimalsID;
            var shelteredAnimalId = ShelteredAnimalMapping.MapToShelteredAnimalId(animalIdToRemove.AnimalId.Value);


            user.GiveAnimalToShelter(animalIdToRemove.AnimalId);
            shelter.TakeAnimalFromClient(request.Client_ID, shelteredAnimalId);

            _animalShelterRepository.Update(shelter);
            _userRepository.Update(user);

            _unitOfWork.SaveChangesAsync().Wait();
            _unitOfWork.Dispose();
        }
    }
}
