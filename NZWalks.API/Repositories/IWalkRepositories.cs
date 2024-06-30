using NZWalks.API.Model.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepositories
    {
        Task<Walks> InsertAsync(Walks walks);
        Task<List<Walks>> GetAllAsync();
        Task<Walks?> GetByIdAsync(Guid id);
        Task<Walks?> UpdateAsync(Guid id, Walks walks);
        Task<bool> DeleteAsync(Guid id);
    }
}
