using Microsoft.EntityFrameworkCore;
using Project_API.Domain.Animal_ShelterAggregate;
using Project_API.Infrastructure.Persistence;

public class AdoptionFactory : IAdoptionFactory
{
    private readonly DbContextOptions<DatabaseContext> _options;

    public AdoptionFactory(DbContextOptions<DatabaseContext> options)
    {
        _options = options;
    }

    public IAdoptionUoW CreateAdoptionUoW()
    {
        var context = new DatabaseContext(_options);
        var animalRepository = new AnimalRepository(context);
        var animalShelterRepository = new AnimalShelterRepository(context);
        var userRepository = new UserRepository(context);
        var unitOfWork = new UnitOfWork(context);
        var adoptionUOW = new AdoptionUoW(animalRepository, userRepository, animalShelterRepository, unitOfWork);
        return adoptionUOW;
    }
}
