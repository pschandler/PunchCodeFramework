using PunchcodeStudios.Domain;

namespace PunchcodeStudios.Application.Contracts.Persisitence
{
    public interface IGalleryRepository : IGenericRepository<Gallery>
    {
        Task<Gallery?> GetGalleryByName(string name);
        Task<bool> GalleryExists(Guid Id, bool includeDeleted = false);
        Task<bool> GalleryIsUnique(string name, bool includeDeleted = false);
    }
}
