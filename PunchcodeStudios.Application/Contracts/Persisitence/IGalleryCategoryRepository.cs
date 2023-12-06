using PunchcodeStudios.Domain;

namespace PunchcodeStudios.Application.Contracts.Persisitence
{
    public interface IGalleryCategoryRepository : IGenericRepository<GalleryCategory>
    {
        Task<GalleryCategory?> GetGalleryCategoriesById(Guid id);
        Task<GalleryCategory?> GetGalleryCategoriesByName(string name);
        Task<IReadOnlyList<GalleryCategory>> GetAllGalleryCategories(bool includeDeleted = false);
        Task<bool> GalleryCategoryExists(string name, bool includeDeleted);
    }
}
