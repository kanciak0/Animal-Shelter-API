using Project_API.Entities.Animal_ShelterAggregate;
using Project_API.Entities.UserAggregate;
using Project_API.Infrastructure.Persistence;
using Project_API.Data;
using Project_API.Domain.Abstract;

public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _context;


    public UnitOfWork(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
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
