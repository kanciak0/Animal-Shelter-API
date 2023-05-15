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
        public async Task DoWork(GiveAnimalFromClientToShelterCommand request)
        {
            var user = _userRepository.GetByID(request.User_ID, "Animals");
            var shelter = _animalShelterRepository.GetByID(request.AnimalShelter_ID, "clients,adoptions");
            var useranimal = user.Animals.FirstOrDefault(x => x.AnimalId.Equals(request.UserAnimalsID));
            var shelteredAnimal = ShelteredAnimalMapping.CreateShelteredAnimalFromUserpet(useranimal, shelter.AnimalShelter_ID);
            var client = ClientMapper.CreateClient(user, shelter, shelter.AnimalShelter_ID);

            user.GiveAnimalToShelter(useranimal.AnimalId);
            shelter.TakeAnimalFromClient(client.Client_UUID,shelteredAnimal.ShelteredAnimal_UUID);

            _animalShelterRepository.Update(shelter);
            _userRepository.Update(user);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
