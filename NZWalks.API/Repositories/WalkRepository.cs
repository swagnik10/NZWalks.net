using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Model.Domain;

namespace NZWalks.API.Repositories
{
    public class WalkRepository : IWalkRepositories
    {
        private readonly NZWalksDbContext DbContext;

        public WalkRepository(NZWalksDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        public async Task<Walks> InsertAsync(Walks walks)
        {
            await DbContext.Walks.AddAsync(walks);
            await DbContext.SaveChangesAsync();
            return walks;
        }

        public async Task<List<Walks>> GetAllAsync()
        {
            return await DbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walks?> GetByIdAsync(Guid id)
        {
            Walks? requiredWalk = await DbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
            return requiredWalk;
        }

        public async Task<Walks?> UpdateAsync(Guid id, Walks walks)
        {
            Walks? requiredWalk = await DbContext.Walks.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (requiredWalk != null)
            {
                requiredWalk.Name = walks.Name;
                requiredWalk.Description = walks.Description;
                requiredWalk.LengthInKm = walks.LengthInKm;
                requiredWalk.WalkImageUrl = walks.WalkImageUrl;
                requiredWalk.RegionId = walks.RegionId;
                requiredWalk.DifficultyId = walks.DifficultyId;

                DbContext.Walks.Update(requiredWalk);
                await DbContext.SaveChangesAsync();
            }
            return requiredWalk;
            
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Walks? walk = await DbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if(walk != null)
            {
                DbContext.Walks.Remove(walk);
                await DbContext.SaveChangesAsync();
                return true;
            }
            return false;
                
        }
    }
}
