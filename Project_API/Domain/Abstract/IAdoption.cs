using Project_API.Domain.Animal_ShelterAggregate;
using Project_API.Entities.Animal_ShelterAggregate;

namespace Project_API.Domain.Abstract
{
    public interface IAdoption
    {
        ICollection<Client_ID> Client_ids { get; }
        int Id { get; }
        ICollection<ShelteredAnimal_ID> ShelteredAnimal_ids { get; }

        void AddToAdoptions(Client_ID clientid, ShelteredAnimal_ID shelteredanimalid);
    }
}