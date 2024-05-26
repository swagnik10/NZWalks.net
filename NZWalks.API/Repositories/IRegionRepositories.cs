using NZWalks.API.Model.Domain;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepositories
    {
        //Defination of method
        Task<List<Regions>> GetAllRegionAsync();
        Task<Regions?> GetRegionsByIDAsync(Guid Id);
        Task<Regions> InsertRegionsAsync(Regions region);
        Task<Regions?> UpdateRegionsAsync(Guid Id, Regions region);
        Task<Regions?> DeleteRegionsAsync(Guid Id);
    }
}
