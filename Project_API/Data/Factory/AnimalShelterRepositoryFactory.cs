using Microsoft.EntityFrameworkCore;
using Project_API.Data.IFactory;
using Project_API.Domain.Animal_ShelterAggregate;
using Project_API.Infrastructure.Persistence;

public class AnimalShelterRepositoryFactory : IAnimalShelterRepositoryFactory
{
    private readonly DbContextOptions<DatabaseContext> _options;

    public AnimalShelterRepositoryFactory(DbContextOptions<DatabaseContext> options)
    {
        _options = options;
    }

    public IAnimalShelterRepository CreateAnimalShelterRepository()
    {
        var context = new DatabaseContext(_options);
        return new AnimalShelterRepository(context);
    }
}
