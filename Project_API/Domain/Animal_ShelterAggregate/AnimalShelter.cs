using Project_API.Domain.Abstract;
using Project_API.Features._AnimalShelter;

namespace Project_API.Entities.Animal_ShelterAggregate
{
    public class AnimalShelter : IClientRegistrationService,IAnimalRegistrationService
    {
        public AnimalShelter_ID AnimalShelter_ID { get; private set; }
        public ICollection<ShelteredAnimal> animals;
        public ICollection<Client> clients;
        public ICollection<Adoption> adoptions;
        private AnimalShelter() { }
        public AnimalShelter(AnimalShelter_ID animalshelterid, ICollection<ShelteredAnimal> animals, ICollection<Client> clients, ICollection<Adoption> adoptions)
        {
            AnimalShelter_ID = animalshelterid;
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
        public Client RegisterClient(Client_ID id, string username, ClientCredentials credentials, ClientAddress address, int age)
        {
            if (clients.Any(c => c.Client_UUID == id))
            {
                return null;
            }

            var client = new Client(id, username, credentials, address, age);
            clients.Add(client);
            return client;
        }
        public ShelteredAnimal RegisterShelteredAnimal(ShelteredAnimal_ID id, string name, ShelteredAnimalSpecies species)
        {
            if (animals.Any(a => a.ShelteredAnimal_UUID == id))
            {
                return null;
            }
            var sheltered_animal = new ShelteredAnimal(id, name, species);
            animals.Add(sheltered_animal);
            return sheltered_animal;
        }
        public void TakeAnimalFromClient(StronglyTypedId<Client_ID> clientid, StronglyTypedId<ShelteredAnimal_ID> shelteredanimalid)
        {
            var client = clients.SingleOrDefault(c => c.Client_UUID == clientid);
            var shelteredanimal = animals.SingleOrDefault(a => a.ShelteredAnimal_UUID == shelteredanimalid);

            if (client.Client_UUID == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                client.SetResponsibility(client._Responsibility == Client.Responsibility.Responsible ?
                    Client.Responsibility.Irresponsible : Client.Responsibility.Irresponsible);
                animals.Add(shelteredanimal);
            }
        }
    }
}
