using Microsoft.EntityFrameworkCore;
using Project_API.Entities;
using Project_API.Infrastructure.Persistence.Configurations;
using System.Reflection;

namespace Project_API.Infrastructure.Persistence
{
    public class DemoDatabaseContext : DbContext
    {
        public DemoDatabaseContext(DbContextOptions<DemoDatabaseContext> options) : base(options)
        {

        }
        public DbSet<User_Entity> Users => Set<User_Entity>();
        public DbSet<Animal_Entity> Animals =>Set<Animal_Entity>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new UserEntityConfiguration().Configure(builder.Entity<User_Entity>());
            new AnimalEntityConfiguration().Configure(builder.Entity<Animal_Entity>());
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);

        }

    }
   
}

