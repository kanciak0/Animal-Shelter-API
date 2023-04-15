using Microsoft.EntityFrameworkCore;
using Project_API.Infrastructure.Persistence;

namespace Project_API.Entities.Animal_ShelterAggregate
{
   internal class AnimalShelterRepository: IAnimalShelterRepository, IDisposable
    {
        private readonly DemoDatabaseContext _dbcontext;
        public AnimalShelterRepository(DemoDatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IEnumerable<Client> GetClientdata()
        {
            return _dbcontext.Clients.ToList();
        }
        public IEnumerable<ShelteredAnimal> GetAnimalData()
        {
            return _dbcontext.ShelteredAnimals.ToList();
        }
        public IEnumerable<Adoption> GetAdoptionData()
        {
            return _dbcontext.Adoptions.ToList();
        }
        public IEnumerable<Adoption> GetSpecificAdoptionData(Adoption id)
        {
            return _dbcontext.Adoptions.Where(adoption => adoption.Id.Equals(id));
        }
        public void DeleteSpecificAdoptionListData(Adoption id)
        {
            Adoption adoption = _dbcontext.Adoptions.FirstOrDefault(adoption => adoption.Id.Equals(id));
            _dbcontext.Adoptions.Remove(adoption);
        }
        public Client GetClientByID(Client_ID clientid)
        {
            return _dbcontext.Clients.FirstOrDefault(client => client.Client_UUID == clientid);
        }
        public void InsertClient(Client client)
        {
            _dbcontext.Clients.Add(client);
        }
        public void DeleteClient (Client_ID clientid)
        {
            Client client = _dbcontext.Clients.FirstOrDefault(client => client.Client_UUID == clientid);
            _dbcontext.Clients.Remove(client);
        }
        public void UpdateClient (Client client)
        {
            _dbcontext.Entry(client).State = EntityState.Modified;
        }
        public ShelteredAnimal GetShelteredAnimalByID(ShelteredAnimal_ID shelteredanimalid)
        {
            return _dbcontext.ShelteredAnimals.FirstOrDefault(shelteredanimal => shelteredanimal.ShelteredAnimal_UUID == shelteredanimalid);
        }
        public void InsertShelteredAnimal(ShelteredAnimal shelteredanimal)
        {
            _dbcontext.ShelteredAnimals.Add(shelteredanimal);
        }
        public void DeleteShelteredAnimal(ShelteredAnimal_ID shelteredanimalid)
        {
            ShelteredAnimal shelteredanimal = _dbcontext.ShelteredAnimals.FirstOrDefault(_shelteredanimal => _shelteredanimal.ShelteredAnimal_UUID == shelteredanimalid);
            _dbcontext.ShelteredAnimals.Remove(shelteredanimal);
        }
        public void UpdateShelteredAnimal(ShelteredAnimal shelteredanimal)
        {
            _dbcontext.Entry(shelteredanimal).State = EntityState.Modified;
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbcontext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
