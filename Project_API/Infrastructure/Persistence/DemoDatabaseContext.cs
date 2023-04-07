using Microsoft.EntityFrameworkCore;
using Project_API.Entities;

namespace Project_API.Infrastructure.Persistence
{
    public class DemoDatabaseContext : DbContext
    {
        public DemoDatabaseContext(DbContextOptions<DemoDatabaseContext> options) : base(options)
        {

        }
        public DbSet<User_entity> Users => Set<User_entity>();
        public DbSet<Animal_entity> Animals =>Set<Animal_entity>(); 
       
    }
   
}

