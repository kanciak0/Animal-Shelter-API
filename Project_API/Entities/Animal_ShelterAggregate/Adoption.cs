using System.Linq;

namespace Project_API.Entities.Animal_ShelterAggregate
{
    public class Adoption
    {
        public int Id { get; private set; }
        public ICollection<ShelteredAnimal_ID> ShelteredAnimal_ids { get; private set; }
        public ICollection<Client_ID> Client_ids { get; private set; }

        public Adoption()
        {
            ShelteredAnimal_ids = new List<ShelteredAnimal_ID>();
            Client_ids = new List<Client_ID>();
        }

        public void AddToAdoptions(Client_ID clientid, ShelteredAnimal_ID shelteredanimalid)
        {
            if (!Client_ids.Contains(clientid))
            {
                Client_ids.Add(clientid);
            }

            if (!ShelteredAnimal_ids.Contains(shelteredanimalid))
            {
                ShelteredAnimal_ids.Add(shelteredanimalid);
            }
        }
    }
}