using PunchcodeStudios.Domain;

namespace PunchcodeStudios.Application.Contracts.Persisitence
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category?> GetCategoryById(Guid id);
        Task<Category?> GetCategoryByName(string name);
        Task<bool> CategoryExists(Guid Id, bool includeDeleted = false);
        Task<bool> CategoryIsUnique(string name, bool includeDeleted = false);
    }
}
