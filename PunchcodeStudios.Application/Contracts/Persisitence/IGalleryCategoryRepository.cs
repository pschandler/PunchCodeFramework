using PunchcodeStudios.Domain;

namespace PunchcodeStudios.Application.Contracts.Persisitence
{
    public interface IGalleryCategoryRepository : IGenericRepository<GalleryCategory>
    {
        Task<GalleryCategory?> GetGalleryCategoryById(Guid id);
        Task<GalleryCategory?> GetGalleryCategoryByName(string name);
        Task<bool> GalleryCategoryExists(Guid Id, bool includeDeleted = false);
        Task<bool> GalleryCategoryIsUnique(string name, bool includeDeleted = false);
    }
}
