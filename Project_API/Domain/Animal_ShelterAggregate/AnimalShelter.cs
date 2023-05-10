using Project_API.Domain.Abstract;

namespace Project_API.Entities.Animal_ShelterAggregate
{
    public class AnimalShelter : IClientRegistrationService,IAnimalRegistrationService
    {
        public AnimalShelter_ID AnimalShelter_ID { get; private set; }

        public ICollection<ShelteredAnimal> shelteredanimals = new List<ShelteredAnimal>();
        public ICollection<Client> clients = new List<Client>();
        public ICollection<Adoption> adoptions = new List<Adoption>();
        private AnimalShelter() { }
        public AnimalShelter(AnimalShelter_ID animalshelterid, ICollection<ShelteredAnimal> animals, ICollection<Client> clients, ICollection<Adoption> adoptions)
        {
            AnimalShelter_ID = animalshelterid;
            this.shelteredanimals = animals;
            this.clients = clients;
            this.adoptions = adoptions;
        }

        public Adoption GiveToAdoption(Client_ID clientid, ShelteredAnimal_ID shelteredanimalid,AnimalShelter_ID animalShelter_ID)
        {
            var shelteredanimal = shelteredanimals.SingleOrDefault(a => a.ShelteredAnimal_UUID.Equals(shelteredanimalid));
            var client = clients.SingleOrDefault(c => c.Client_UUID.Equals(clientid));

            if (client.Client_UUID == null) { throw new NotImplementedException(); }
            else if (client.Age <= 18) { throw new NotImplementedException(); }
    //        else if (shelteredanimal.Condition == ShelteredAnimal.HealthCondition.Sick) { throw new NotImplementedException(); }
            else if (shelteredanimal.Status == ShelteredAnimal.AdoptionStatus.Adopted) { throw new NotImplementedException(); }
            else if (client._Responsibility == Client.Responsibility.Irresponsible) { throw new NotImplementedException(); }
            else
            {
                var adoption = new Adoption(shelteredanimal.ShelteredAnimal_UUID, client.Client_UUID,animalShelter_ID);
                shelteredanimal.SetAdoptionStatus(ShelteredAnimal.AdoptionStatus.Adopted);
                adoptions.Add(adoption);
                return adoption;
            }
         }
        public  Client RegisterClient(Client_ID id, string username, ClientCredentials credentials, ClientAddress address, int age,AnimalShelter_ID animalShelter_ID)
        {
            if (clients.Any(c => c.Client_UUID == id))
            {
                return null;
            }

            var client = new Client(id, username, credentials, address, age,animalShelter_ID);
            clients.Add(client);
            return client;
        }
        public ShelteredAnimal RegisterShelteredAnimal(ShelteredAnimal_ID id,string name, ShelteredAnimalSpecies species,AnimalShelter_ID animalShelter_ID)
        {
            var sheltered_animal = new ShelteredAnimal(id,name, species,animalShelter_ID);
            shelteredanimals.Add(sheltered_animal);
            return sheltered_animal;
        }
        public void TakeAnimalFromClient(Client_ID clientid, ShelteredAnimal_ID shelteredanimalid)
        {
            var client = clients.SingleOrDefault(c => c.Client_UUID.Equals(clientid));
            var shelteredanimal = shelteredanimals.SingleOrDefault(a => a.ShelteredAnimal_UUID == shelteredanimalid);

            if (client.Client_UUID == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                client.SetResponsibility(Client.Responsibility.Irresponsible);

                shelteredanimals.Add(shelteredanimal);
            }
        }
    }
}
