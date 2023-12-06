using PunchcodeStudios.Domain;

namespace PunchcodeStudios.Application.Contracts.Persisitence
{
    public interface IGalleryTypeRepository: IGenericRepository<GalleryType>
    {
        Task<GalleryType?> GetGalleryTypesById(Guid id);
        Task<GalleryType?> GetGalleryTypesByName(string name);
        Task<IReadOnlyList<GalleryType>> GetAllGalleryTypes(bool includeDeleted = false);
        Task<bool> GalleryTypeExists(string name, bool includeDeleted);
    }
}
