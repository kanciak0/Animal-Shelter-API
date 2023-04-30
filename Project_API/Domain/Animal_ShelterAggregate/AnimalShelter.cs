using Project_API.Domain.Abstract;

namespace Project_API.Entities.Animal_ShelterAggregate
{
    public class AnimalShelter
    {
     
        private static readonly int _animalShelterId;

        static AnimalShelter()
        {
            _animalShelterId = 1;
        }
        public int animal_shelter_Id => _animalShelterId;
        public ICollection<ShelteredAnimal> animals;
        public ICollection<Client> clients;
        public ICollection<Adoption> adoptions;

        public AnimalShelter(ICollection<ShelteredAnimal> animals, ICollection<Client> clients, ICollection<Adoption> adoptions)
        {
            this.animals = animals;
            this.clients = clients;
            this.adoptions = adoptions;
        }

        public Adoption GiveToAdoption(StronglyTypedId<Client_ID> clientid, StronglyTypedId<ShelteredAnimal_ID> shelteredanimalid)
        {
            var shelteredanimal = animals.SingleOrDefault(a => a.ShelteredAnimal_UUID == shelteredanimalid);
            var client = clients.SingleOrDefault(c => c.Client_UUID == clientid);
            
            if (client.Client_UUID == null) { throw new NotImplementedException(); }
            else if (client.Age <= 18) { throw new NotImplementedException(); }
            else if (shelteredanimal.Condition == ShelteredAnimal.HealthCondition.Sick) { throw new NotImplementedException(); }
            else if (shelteredanimal.Status == ShelteredAnimal.AdoptionStatus.Adopted) { throw new NotImplementedException(); }
            else if (client._Responsibility == Client.Responsibility.Irresponsible) { throw new NotImplementedException(); }
            else
            {
                var adoption = new Adoption(shelteredanimal.ShelteredAnimal_UUID, client.Client_UUID);
                shelteredanimal.SetAdoptionStatus(ShelteredAnimal.AdoptionStatus.Adopted);
                adoptions.Add(adoption);
                return adoption;
            }
        }
        public Client RegisterClient(Client_ID id,string username,ClientCredentials credentials, ClientAddress address,int age)
        {
            var client = new Client(id, username,credentials, address, age);
            clients.Add(client);
            return client;
        }
    }
}
