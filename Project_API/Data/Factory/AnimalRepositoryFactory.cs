using Microsoft.EntityFrameworkCore;

public class AnimalRepositoryFactory : IAnimalRepositoryFactory
{
    private readonly DbContext _context;

    public AnimalRepositoryFactory(DbContext context)
    {
        _context = context;
    }

    public IAnimalRepository CreateAnimalRepository()
    {
        return new AnimalRepository(_context);
    }
}
