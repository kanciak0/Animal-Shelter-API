using Microsoft.EntityFrameworkCore;
using Project_API.Entities.Animal_ShelterAggregate;
using Project_API.Entities.AnimalAggregate;
using Project_API.Entities.UserAggregate;
using Project_API.Infrastructure.Persistence.Configurations;
using System.Reflection;
using System.Reflection.Emit;

namespace Project_API.Infrastructure.Persistence
{
    public class DemoDatabaseContext : DbContext
    {
        public DemoDatabaseContext(DbContextOptions<DemoDatabaseContext> options) : base(options)
        {

        }
        public DbSet<User> Users => base.Set<User>();
        public DbSet<Animal> Animals => base.Set<Animal>();
        public DbSet<Client> Clients => base.Set<Client>();
        public DbSet<ShelteredAnimal> ShelteredAnimals => base.Set<ShelteredAnimal>();
        public DbSet<Adoption> Adoptions => base.Set<Adoption>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            new UserEntityConfiguration().Configure(builder.Entity<User>());
            new AnimalEntityConfiguration().Configure(builder.Entity<Animal>());
            new ClientEntityConfiguration().Configure(builder.Entity<Client>());
            new ShelteredAnimalEntityConfiguration().Configure(builder.Entity<ShelteredAnimal>());
            new AdoptionConfiguration().Configure(builder.Entity<Adoption>());
            builder.ApplyConfiguration(new UserAnimalsIDConfiguration());
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}

