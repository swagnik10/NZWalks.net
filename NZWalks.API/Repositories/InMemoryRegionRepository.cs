using NZWalks.API.Model.Domain;

namespace NZWalks.API.Repositories
{
    public class InMemoryRegionRepository : IRegionRepositories
    {
        Task<Regions?> IRegionRepositories.DeleteRegionsAsync(Guid Id)
        {
            throw new NotImplementedException();
        }
        
        public async Task<List<Regions>> GetAllRegionAsync()
        {
            List<Regions> regionList = new List<Regions>
            {
                new Regions
                {
                    Id = Guid.NewGuid(),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = ""
                },
                new Regions
                {
                    Id = Guid.NewGuid(),
                    Name = "Bay of Plenty",
                    Code = "BOP",
                    RegionImageUrl = ""
                },
                new Regions
                {
                    Id = Guid.NewGuid(),
                    Name = "Canterbury.",
                    Code = "CAB",
                    RegionImageUrl = ""
                },
                new Regions
                {
                    Id = Guid.NewGuid(),
                    Name = "Hawke's Bay",
                    Code = "HAB",
                    RegionImageUrl = ""
                },
            };
            return regionList;
        }

        Task<Regions?> IRegionRepositories.GetRegionsByIDAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        Task<Regions> IRegionRepositories.InsertRegionsAsync(Regions region)
        {
            throw new NotImplementedException();
        }

        Task<Regions?> IRegionRepositories.UpdateRegionsAsync(Guid Id, Regions region)
        {
            throw new NotImplementedException();
        }
    }
}
