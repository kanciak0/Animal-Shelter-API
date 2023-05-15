using Project_API.Domain.Animal_ShelterAggregate;
using Project_API.Features._AnimalShelter;

public interface IAdoptionUoW
{
    Task DoWork(AdoptCommand request);

}