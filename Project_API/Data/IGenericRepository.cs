using System.Linq.Expressions;


namespace Project_API.Data
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        TEntity GetByID(StronglyTypedId<TEntity> id);

        void Insert(TEntity entity);

        void Delete(StronglyTypedId<TEntity> id);

        void Delete(TEntity entityToDelete);
            
        void Update(TEntity entityToUpdate);

        void Save();
        Task SaveChangesAsync();
    }
}
