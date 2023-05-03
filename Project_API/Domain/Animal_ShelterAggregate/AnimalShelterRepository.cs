using Microsoft.EntityFrameworkCore;
using Project_API.Data;
using Project_API.Domain.Abstract;
using Project_API.Entities.Animal_ShelterAggregate;
using Project_API.Entities.UserAggregate;
using Project_API.Infrastructure.Persistence;
using System.Linq.Expressions;

namespace Project_API.Domain.Animal_ShelterAggregate
{
    internal class AnimalShelterRepository : IAnimalShelterRepository
    {
        private readonly DatabaseContext _dbcontext;
        public AnimalShelterRepository(DatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void Delete(StronglyTypedId<AnimalShelter> id)
        {
            var entityToDelete = _dbcontext.Set<AnimalShelter>().FirstOrDefault(e => e.AnimalShelter_ID.Equals(id));
            if (entityToDelete != null)
            {
                _dbcontext.Set<AnimalShelter>().Remove(entityToDelete);
            }
        }
        public IEnumerable<AnimalShelter> Get(Expression<Func<AnimalShelter, bool>> filter = null, Func<IQueryable<AnimalShelter>, IOrderedQueryable<AnimalShelter>> orderBy = null, string includeProperties = "")
        {
            IQueryable<AnimalShelter> query = _dbcontext.Set<AnimalShelter>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public AnimalShelter GetByID(StronglyTypedId<AnimalShelter> id)
        {
            return _dbcontext.Set<AnimalShelter>().FirstOrDefault(e => e.AnimalShelter_ID.Equals(id));
        }

        public void Insert(AnimalShelter entity)
        {
            _dbcontext.Set<AnimalShelter>().Add(entity);
        }

        public void Update(AnimalShelter entityToUpdate)
        {
            _dbcontext.Set<AnimalShelter>().Update(entityToUpdate);
        }
        public void Save()
        {
            _dbcontext.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
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
