using Microsoft.EntityFrameworkCore;
using Project_API.Infrastructure.Persistence;

public class AnimalRepositoryFactory : IAnimalRepositoryFactory
{
    private readonly DatabaseContext _context;

    public AnimalRepositoryFactory(DatabaseContext context)
    {
        _context = context;
    }

    public IAnimalRepository CreateAnimalRepository()
    {
        return new AnimalRepository(_context);
    }
}
