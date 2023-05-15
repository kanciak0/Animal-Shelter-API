using Project_API.Common.Mappings;
using Project_API.Domain.Animal_ShelterAggregate;
using Project_API.Entities.Animal_ShelterAggregate;
using Project_API.Entities.UserAggregate;
using Project_API.Features._AnimalShelter;

public class AdoptionUoW:IAdoptionUoW
{
    private readonly IAnimalShelterRepository _animalShelterRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AdoptionUoW(IUserRepository userRepository, IAnimalShelterRepository animalShelterRepository, IUnitOfWork unitOfWork)
    {
        _animalShelterRepository = animalShelterRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task DoWork(AdoptCommand request)
    {
        var user = _userRepository.GetByID(request.User_Id);
        var shelter = _animalShelterRepository.GetByID(request.AnimalShelter_ID, "shelteredanimals");
        var client = ClientMapper.CreateClient(user, shelter, shelter.AnimalShelter_ID);
        var shelteredanimal = shelter.shelteredanimals.FirstOrDefault(x => x.ShelteredAnimal_UUID.Equals(request.ShelteredAnimal_ID));
        UserAnimals useranimal = ShelteredAnimalMapping.ToUserAnimal(shelteredanimal,user.User_UUID);

        shelter.GiveToAdoption(client.Client_UUID, shelteredanimal.ShelteredAnimal_UUID,shelter.AnimalShelter_ID);

        user.Adopt(useranimal);
        _userRepository.Update(user);
        _animalShelterRepository.Update(shelter);

        await _unitOfWork.SaveChangesAsync();
    }
}
