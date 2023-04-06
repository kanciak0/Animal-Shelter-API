using Microsoft.EntityFrameworkCore;
using Project_API.Entities;

namespace Project_API.Infrastructure.Persistence
{
    public class DemoDatabaseContext : DbContext
    {
        public DemoDatabaseContext(DbContextOptions<DemoDatabaseContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }
       
    }
   
}

