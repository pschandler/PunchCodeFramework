using PunchcodeStudios.Domain.Common;

namespace PunchcodeStudios.Application.Contracts.Persisitence
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAsync(bool includeDeleted = false);
        Task<T?> GetByIdAsync(Guid id);
        Task<T> CreateAsync(T entity);  
        Task<bool> UpdateAsync(T entity);  
        Task<bool> DeleteAsync(T entity);
    }
}
