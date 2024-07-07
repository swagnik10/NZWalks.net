using NZWalks.API.Model.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepositories
    {
        Task<Walks> InsertAsync(Walks walks);
        Task<List<Walks>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortOn =null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000 );
        Task<Walks?> GetByIdAsync(Guid id);
        Task<Walks?> UpdateAsync(Guid id, Walks walks);
        Task<bool> DeleteAsync(Guid id);
    }
}
