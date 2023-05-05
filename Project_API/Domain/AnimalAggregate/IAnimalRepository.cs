using System.Linq.Expressions;

public interface IAnimalRepository:IDisposable
{
    void Delete(StronglyTypedId<Guid> id);
    IEnumerable<Animal> Get(Expression<Func<Animal, bool>> filter = null, Func<IQueryable<Animal>, IOrderedQueryable<Animal>> orderBy = null, string includeProperties = "");
    Animal GetByID(StronglyTypedId<Guid> id);
    void Insert(Animal entity);
    void Save();
    Task SaveChangesAsync();
    void Update(Animal entityToUpdate);
}