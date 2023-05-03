using System.Linq;
using Project_API.Domain.Abstract;

namespace Project_API.Entities.Animal_ShelterAggregate
{
    public class Adoption
    {
        private static int nextId = 1;
        public AnimalShelter_ID animal_shelter_Id { get; }

        public int Id { get; private set; }
        public ShelteredAnimal_ID ShelteredAnimal_id { get; private set; }
        public Client_ID Client_id { get; private set; }
        public AnimalShelter AnimalShelter { get; }
        public Adoption(ShelteredAnimal_ID shelteredAnimal_id, Client_ID client_id)
        {
            Id = nextId++;
            ShelteredAnimal_id = shelteredAnimal_id;
            Client_id = client_id;
        }
    }
}
