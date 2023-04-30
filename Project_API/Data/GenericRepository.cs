using Microsoft.EntityFrameworkCore;
using Project_API.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Project_API.Data
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal DatabaseContext _dbcontext;
        internal DbSet<TEntity> _entities;
        public GenericRepository(DatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
            _entities = dbcontext.Set<TEntity>();
        }
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
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
        public virtual TEntity GetByID(StronglyTypedId<TEntity> id)
        {
            return _entities.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            _entities.Add(entity);
        }

        public virtual void Delete(StronglyTypedId<TEntity> id)
        {
            TEntity entityToDelete = _entities.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_dbcontext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _entities.Attach(entityToDelete);
            }
            _entities.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _entities.Attach(entityToUpdate);
            _dbcontext.Entry(entityToUpdate).State = EntityState.Modified;
        }
        public void Save()
        {
            _dbcontext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
