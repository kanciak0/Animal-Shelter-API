using Microsoft.EntityFrameworkCore;
using Project_API.Infrastructure.Persistence;

namespace Project_API.Entities.AnimalAggregate
{
    public class AnimalRepository : IAnimalRepository,IDisposable
    {
        private DemoDatabaseContext _dbcontext;
        public AnimalRepository(DemoDatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IEnumerable<Animal> GetAnimals()
        {
            return _dbcontext.Animals.ToList();
        }
        public Animal GetAnimalByID(Animal_ID animal_id)
        {
            return _dbcontext.Animals.FirstOrDefault(animal => animal.Animal_UUID == animal_id);
        }
        public void InsertAnimal(Animal animal)
        {
            _dbcontext.Animals.Add(animal);
        }
        public void DeleteAnimal(Animal_ID animal_id)
        {
            Animal animal = _dbcontext.Animals.FirstOrDefault(animal => animal.Animal_UUID == animal_id);
            _dbcontext.Animals.Remove(animal);
        }
        public void UpdateAnimal(Animal animal)
        {
            _dbcontext.Entry(animal).State = EntityState.Modified;
        }
        public void Save()
        {
            _dbcontext.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbcontext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
    
}
