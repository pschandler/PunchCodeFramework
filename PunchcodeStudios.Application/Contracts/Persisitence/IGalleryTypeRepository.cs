using PunchcodeStudios.Domain;

namespace PunchcodeStudios.Application.Contracts.Persisitence
{
    public interface IGalleryTypeRepository: IGenericRepository<GalleryType>
    {
        Task<GalleryType?> GetTypesById(Guid id);
        Task<GalleryType?> GetTypesByName(string name);
        Task<IReadOnlyList<GalleryType>> GetAllTypes(bool includeDeleted = false);
        Task<bool> GalleryTypeExists(string name, bool includeDeleted);
    }
}
