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

    public void DoWork(AdoptCommand request)
    {
        var user = _userRepository.GetByID(request.User_Id);
        var shelter = _animalShelterRepository.GetByID(request.AnimalShelter_ID);
        var client = ClientMapper.CreateClient(user, shelter);


        shelter.GiveToAdoption(client.Client_UUID, request.ShelteredAnimal_ID);

        user.Adopt(request.animal_Id,request.Name);

        _userRepository.Update(user);
        _animalShelterRepository.Update(shelter);

        _unitOfWork.SaveChangesAsync().Wait();
        _unitOfWork.Dispose();
    }
}
