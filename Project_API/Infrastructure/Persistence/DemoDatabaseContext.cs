using Microsoft.EntityFrameworkCore;
using Project_API.Entities;
using System.Reflection;

namespace Project_API.Infrastructure.Persistence
{
    public class DemoDatabaseContext : DbContext
    {
        public DemoDatabaseContext(DbContextOptions<DemoDatabaseContext> options) : base(options)
        {

        }
        public DbSet<User_entity> Users => Set<User_entity>();
        public DbSet<Animal_entity> Animals =>Set<Animal_entity>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
   
}

