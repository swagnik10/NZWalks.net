using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Model.Domain;

namespace NZWalks.API.Repositories
{
    public class RegionRepository : IRegionRepositories
    {
        private readonly NZWalksDbContext nzWalksDbContext;

        public RegionRepository(NZWalksDbContext nzWalksDbContext)
        {
            this.nzWalksDbContext = nzWalksDbContext;
        }
        //Implementations
        public async Task<List<Regions>> GetAllRegionAsync()
        {
            List<Regions> regionList = await nzWalksDbContext.Regions.ToListAsync();
            return regionList;
        }

        public async Task<Regions?> GetRegionsByIDAsync(Guid Id)
        {
            Regions requiedRegion = await nzWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);
            return requiedRegion;
        }

        public async Task<Regions> InsertRegionsAsync(Regions region)
        {
            await nzWalksDbContext.AddAsync(region);
            await nzWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Regions?> UpdateRegionsAsync(Guid Id, Regions region)
        {
            Regions requiredRegion = await nzWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);
            if (requiredRegion != null) 
            {
                requiredRegion.Code = region.Code;
                requiredRegion.Name = region.Name;
                requiredRegion.RegionImageUrl = region.RegionImageUrl;

                await nzWalksDbContext.SaveChangesAsync();

                return requiredRegion;
            }
            return null;
        }

        public async Task<Regions?> DeleteRegionsAsync(Guid Id)
        {
            Regions requiredRegion = await nzWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);
            if (requiredRegion != null)
            {
                 nzWalksDbContext.Remove(requiredRegion);
                await nzWalksDbContext.SaveChangesAsync();
                Console.WriteLine("Hi!!!!");
                return requiredRegion;
            }
            return null;
        }
    }
}
