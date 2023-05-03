using Microsoft.EntityFrameworkCore;
using Project_API.Data;
using Project_API.Domain.Abstract;
using Project_API.Entities.UserAggregate;
using Project_API.Infrastructure.Persistence;
using System.Linq.Expressions;

public class AnimalRepository : IAnimalRepository
{
    private readonly DatabaseContext _context;

    public AnimalRepository(DatabaseContext context)
    {
        _context = context;
    }

    public void Delete(StronglyTypedId<Animal> id)
    {
        var entityToDelete = _context.Set<Animal>().FirstOrDefault(e => e.Animal_UUID.Equals(id));
        if (entityToDelete != null)
        {
            _context.Set<Animal>().Remove(entityToDelete);
        }
    }
    public IEnumerable<Animal> Get(Expression<Func<Animal, bool>> filter = null, Func<IQueryable<Animal>, IOrderedQueryable<Animal>> orderBy = null, string includeProperties = "")
    {
        IQueryable<Animal> query = _context.Set<Animal>();

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

    public Animal GetByID(StronglyTypedId<Animal> id)
    {
        return _context.Set<Animal>().FirstOrDefault(e => e.Animal_UUID.Equals(id));
    }

    public void Insert(Animal entity)
    {
        _context.Set<Animal>().Add(entity);
    }

    public void Update(Animal entityToUpdate)
    {
        _context.Set<Animal>().Update(entityToUpdate);
    }
    public void Save()
    {
        _context.SaveChanges();
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
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
