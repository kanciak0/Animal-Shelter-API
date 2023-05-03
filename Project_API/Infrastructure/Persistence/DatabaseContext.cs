using Microsoft.EntityFrameworkCore;
using Project_API.Entities.Animal_ShelterAggregate;
using Project_API.Entities.UserAggregate;
using Project_API.Infrastructure.Persistence.Configurations;
using System.Reflection;

namespace Project_API.Infrastructure.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DatabaseContext() { }

        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ShelteredAnimal> ShelteredAnimals { get; set; }
        public DbSet<Adoption> Adoptions { get; set; }
        public DbSet<AnimalShelter> Shelters { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            new UserEntityConfiguration().Configure(builder.Entity<User>());
            new AnimalEntityConfiguration().Configure(builder.Entity<Animal>());
            new ClientEntityConfiguration().Configure(builder.Entity<Client>());
            new ShelteredAnimalEntityConfiguration().Configure(builder.Entity<ShelteredAnimal>());
            new AdoptionConfiguration().Configure(builder.Entity<Adoption>());
            new AnimalShelterConfiguration().Configure(builder.Entity<AnimalShelter>());

            builder.Entity<User>()
            .HasMany(u => u.AnimalIds)
            .WithOne()
            .HasForeignKey(a => a.Animal_ID)
            .OnDelete(DeleteBehavior.Cascade);
        }

    }
}


