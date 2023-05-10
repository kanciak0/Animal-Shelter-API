using Microsoft.EntityFrameworkCore;
using Project_API.Data;
using Project_API.Domain.Abstract;
using Project_API.Entities.UserAggregate;
using Project_API.Infrastructure.Persistence;
using System.Linq.Expressions;

public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _context;

    public UserRepository(DatabaseContext context)
    {
        _context = context;
    }

    public void Delete(User_ID id)
    {
        var entityToDelete = _context.Set<User>().FirstOrDefault(e => e.User_UUID.Equals(id));
        if (entityToDelete != null)
        {
            _context.Set<User>().Remove(entityToDelete);
            _context.Entry(entityToDelete).State = EntityState.Deleted;
        }
    }
    public IEnumerable<User> Get(Expression<Func<User, bool>> filter = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null, string includeProperties = "")
    {
        IQueryable<User> query = _context.Set<User>();

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

    public User GetByID(User_ID id)
    {
        return _context.Set<User>().FirstOrDefault(e => e.User_UUID.Equals(id));
    }

    public void Insert(User entity)
    {
        _context.Set<User>().Add(entity);
    }

    public void Update(User entityToUpdate)
    {
        _context.Set<User>().Update(entityToUpdate);
        _context.Entry(entityToUpdate).State = EntityState.Modified;
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
