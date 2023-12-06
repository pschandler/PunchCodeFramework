using Microsoft.EntityFrameworkCore;
using PunchcodeStudios.Application.Contracts.Persisitence;
using PunchcodeStudios.Domain;
using PunchcodeStudios.Persistence.DatabaseContext;

namespace PunchcodeStudios.Persistence.Repositories
{
    public class GalleryCategoryRepository : GenericRepository<GalleryCategory>, IGalleryCategoryRepository
    {
        public GalleryCategoryRepository(PCStudioDbContext context) : base(context)
        {

        }

        public Task<bool> GalleryCategoryExists(string name, bool includeDeleted = false)
        {
            return includeDeleted 
                ? _context.GalleryCategories.AnyAsync(q => q.Name == name)
                : _context.GalleryCategories.AnyAsync(q => q.Name == name && q.DateDeleted == null);
        }

        public async Task<IReadOnlyList<GalleryCategory>> GetAllGalleryCategories(bool includeDeleted = false)
        {
            var galleryCategories = await _context.GalleryCategories.ToListAsync();
            return includeDeleted 
                ? galleryCategories 
                : galleryCategories.Where(q => q.DateDeleted == null).ToList();
        }

        public async Task<GalleryCategory?> GetGalleryCategoriesById(Guid id)
        {
            var galleryCategory = await _context.GalleryCategories.FirstOrDefaultAsync(q => q.Id == id);
            return galleryCategory;
        }

        public async Task<GalleryCategory?> GetGalleryCategoriesByName(string name)
        {
            var galleryCategory = await _context.GalleryCategories.FirstOrDefaultAsync(q => q.Name == name && q.DateDeleted == null);
            return galleryCategory;
        }
    }
}
