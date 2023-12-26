using Microsoft.EntityFrameworkCore;
using PunchcodeStudios.Application.Contracts.Persisitence;
using PunchcodeStudios.Domain;
using PunchcodeStudios.Persistence.DatabaseContext;

namespace PunchcodeStudios.Persistence.Repositories
{
    public class GalleryTypeRepository : GenericRepository<GalleryType>, IGalleryTypeRepository
    {
        public GalleryTypeRepository(PCStudioDbContext context) : base(context)
        {

        }

        public Task<bool> GalleryTypeExists(string name, bool includeDeleted)
        {
            return includeDeleted
            ? _context.GalleryTypes.AnyAsync(q => q.Name == name)
            : _context.GalleryTypes.AnyAsync(q => q.Name == name && q.DateDeleted == null);
        }

        public async Task<IReadOnlyList<GalleryType>> GetAllTypes(bool includeDeleted = false)
        {
            var galleryTypes = await _context.GalleryTypes.ToListAsync();
            return includeDeleted
                ? galleryTypes
                : galleryTypes.Where(q => q.DateDeleted == null).ToList();
        }

        public async Task<GalleryType?> GetTypesById(Guid id)
        {
            var galleryType = await _context.GalleryTypes.FirstOrDefaultAsync(q => q.Id == id);
            return galleryType;
        }

        public async Task<GalleryType?> GetTypesByName(string name)
        {
            var galleryType = await _context.GalleryTypes.FirstOrDefaultAsync(q => q.Name == name && q.DateDeleted == null);
            return galleryType;
        }
    }
}
