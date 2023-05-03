using Project_API.Domain;
using Project_API.Domain.Abstract;
using Project_API.Domain.Animal_ShelterAggregate;
using Project_API.Entities.Animal_ShelterAggregate;
using Project_API.Entities.UserAggregate;
using Project_API.Features._AnimalShelter;
using Project_API.Infrastructure.Persistence;

public class AdoptionUoW:IAdoptionUoW
{
    private readonly IAnimalRepository _animalRepository;
    private readonly IAnimalShelterRepository _animalShelterRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AdoptionUoW(IAnimalRepository animalRepository, IUserRepository userRepository, IAnimalShelterRepository animalShelterRepository, IUnitOfWork unitOfWork)
    {
        _animalRepository = animalRepository;
        _animalShelterRepository = animalShelterRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public void DoWork(AdoptCommand request)
    {
        var user = _userRepository.GetByID(new StronglyTypedId<User>(request.User_Id.ToGuid()));
        var animal = _animalRepository.GetByID(new StronglyTypedId<Animal>(request.Animal_ID.ToGuid()));
        var shelter = _animalShelterRepository.GetByID(new StronglyTypedId<AnimalShelter>(request.AnimalShelter_ID.ToGuid()));
        var client = ClientMapper.CreateClient(user, shelter);


        shelter.GiveToAdoption(client.Client_UUID, request.ShelteredAnimal_ID);

        user.Adopt(new StronglyTypedId<UserAnimalsID>(animal.Animal_UUID.ToGuid()));

        _animalRepository.Update(animal);
        _userRepository.Update(user);
        _animalShelterRepository.Update(shelter);
        _unitOfWork.SaveChangesAsync().Wait();
        _unitOfWork.Dispose();
    }
}
