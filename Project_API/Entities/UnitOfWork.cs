using Microsoft.EntityFrameworkCore;
using Project_API.Entities.Animal_ShelterAggregate;
using Project_API.Entities.AnimalAggregate;
using Project_API.Entities.UserAggregate;
using Project_API.Infrastructure.Persistence;

namespace Project_API.Entities
{
    public class UnitOfWork:IDisposable
    {
        private DemoDatabaseContext _dbcontext = new DemoDatabaseContext(new DbContextOptions<DemoDatabaseContext>());
        private GenericRepository<Animal> animalrepository;
        private GenericRepository<User> userrepository;
        private GenericRepository<AnimalShelter> animalshelterrepository;
        public GenericRepository<Animal> AnimalRepository
        {
            get
            {
                if (animalrepository == null)
                {
                    animalrepository = new GenericRepository<Animal>(_dbcontext);
                }
                return animalrepository;
            }
        }
        public GenericRepository<User> UserRepository
        {
            get
            {
                if (userrepository == null)
                {
                    userrepository = new GenericRepository<User>(_dbcontext);
                }
                return userrepository;
            }
        }
        public GenericRepository<AnimalShelter> AnimalShelterRepository
        {
            get
            {
                if (animalshelterrepository == null)
                {
                    animalshelterrepository = new GenericRepository<AnimalShelter>(_dbcontext);
                }
                return animalshelterrepository;
            }
        }
        public void Save()
        {
            _dbcontext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
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
