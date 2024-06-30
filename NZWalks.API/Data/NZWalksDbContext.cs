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

        //Seeding in DB by ONMODELCREATING method shortcut : write override type OnModel...
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<Difficulty> dificultyList = new List<Difficulty>()
            {
                new Difficulty
                {
                    Id = Guid.Parse("0c5a142c-8721-453d-8760-9411a2507a19"),
                    Name = "Easy"
                },
                new Difficulty
                {
                    Id = Guid.Parse("e2ca28ef-cbbf-49ce-aecd-297594df1e32"),
                    Name = "Medium"
                },
                new Difficulty
                {
                    Id = Guid.Parse("9d869dbc-e650-49ea-8d07-64e62e7a66b3"),
                    Name = "Hard"
                }
            };

            //Seeding Difficulties to Database
            modelBuilder.Entity<Difficulty>().HasData(dificultyList);

            // Seed data for Regions
            List<Regions> regionList = new List<Regions>
            {
                new Regions
                {
                    Id = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Regions
                {
                    Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = null
                },
                new Regions
                {
                    Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new Regions
                {
                    Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Regions
                {
                    Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Regions
                {
                    Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                },
            };

            //Seeding Regions to database
            modelBuilder.Entity<Regions>().HasData(regionList);
        }
    }
}
