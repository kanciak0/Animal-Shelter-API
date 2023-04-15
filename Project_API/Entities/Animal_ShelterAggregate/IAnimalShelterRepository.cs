using System.Collections.Generic;

namespace Project_API.Entities.Animal_ShelterAggregate
{
    public interface IAnimalShelterRepository:IDisposable
    {
        IEnumerable<Client> GetClientdata();
        IEnumerable<ShelteredAnimal> GetAnimalData();
        IEnumerable<Adoption> GetAdoptionData();
        IEnumerable<Adoption> GetSpecificAdoptionData(Adoption id);
        void DeleteSpecificAdoptionListData(Adoption id);
        Client GetClientByID(Client_ID clientid);
        void InsertClient(Client client);
        void DeleteClient(Client_ID clientid);
        void UpdateClient(Client client);
        ShelteredAnimal GetShelteredAnimalByID(ShelteredAnimal_ID shelteredanimalid);
        void InsertShelteredAnimal(ShelteredAnimal shelteredanimal);
        void DeleteShelteredAnimal(ShelteredAnimal_ID shelteredanimalid);
        void UpdateShelteredAnimal(ShelteredAnimal shelteredanimal);
        void Save();
    }
}