using Project_API.Entities.AnimalAggregate;
using System.Linq.Expressions;

public interface IAnimalRepository:IDisposable
{
    void Delete(Animal_ID id);
    IEnumerable<Animal> Get(Expression<Func<Animal, bool>> filter = null, Func<IQueryable<Animal>, IOrderedQueryable<Animal>> orderBy = null, string includeProperties = "");
    Animal GetByID(Animal_ID id);
    void Insert(Animal entity);
    void Save();
    Task SaveChangesAsync();
    void Update(Animal entityToUpdate);
}