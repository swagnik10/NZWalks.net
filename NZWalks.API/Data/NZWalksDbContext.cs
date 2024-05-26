using Microsoft.EntityFrameworkCore;
using NZWalks.API.Model.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        //constructor shortcut type ctor then enter
        public NZWalksDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        //dbset is a property of dbcontext class that represnts a collection of entities in database
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<Walks> Walks { get; set; }
    }
}
