using Project_API.Domain.Animal_ShelterAggregate;

namespace Project_API.Data.IFactory
{
    public interface IAnimalShelterRepositoryFactory
    {
        IAnimalShelterRepository CreateAnimalShelterRepository();
    }
}