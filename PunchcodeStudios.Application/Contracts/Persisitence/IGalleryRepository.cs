using PunchcodeStudios.Domain;

namespace PunchcodeStudios.Application.Contracts.Persisitence
{
    public interface IGalleryRepository : IGenericRepository<Gallery>
    {
        Task<Gallery?> GetGalleryByName(string name);
        //Task<IReadOnlyList<Gallery>> GetGalleriesByTypeId(Guid typeId, bool includeDeleted = false);
        //Task<IReadOnlyList<Gallery>> GetGalleriesByTypeName(string typeName, bool includeDeleted = false);
        //Task<IReadOnlyList<Gallery>> GetGalleriesByCategoryId(Guid categoryId, bool includeDeleted = false);
        //Task<IReadOnlyList<Gallery>> GetGalleriesByCategoryName(string categoryName, bool includeDeleted = false);
        Task<bool> GalleryExists(Guid Id, bool includeDeleted = false);
        Task<bool> GalleryIsUnique(string name, bool includeDeleted = false);
    }
}
