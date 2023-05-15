using Project_API.Features._AnimalShelter;

namespace Project_API.Domain.Abstract
{
    public interface IGiveAnimalToShelterUoW
    {
        Task DoWork(GiveAnimalFromClientToShelterCommand request);
    }
}