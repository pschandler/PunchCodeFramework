using Microsoft.EntityFrameworkCore;
using PunchcodeStudios.Application.Contracts.Persisitence;
using PunchcodeStudios.Domain;
using PunchcodeStudios.Persistence.DatabaseContext;

namespace PunchcodeStudios.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(PCStudioDbContext context) : base(context)
        {

        }

        public Task<bool> CategoryExists(Guid Id, bool includeDeleted = false)
        {
            return includeDeleted
                ? _context.Categories.AnyAsync(q => q.Id == Id)
                : _context.Categories.AnyAsync(q => q.Id == Id && q.DateDeleted == null);
        }

        public Task<bool> CategoryIsUnique(string name, bool includeDeleted = false)
        {
            return includeDeleted 
                ? _context.Categories.AnyAsync(q => q.Name == name)
                : _context.Categories.AnyAsync(q => q.Name == name && q.DateDeleted == null);
        }

        //public async Task<IReadOnlyList<Category>> GetAllCategories(bool includeDeleted = false)
        //{
        //    var galleryCategories = await _context.Categories.ToListAsync();
        //    return includeDeleted 
        //        ? galleryCategories 
        //        : galleryCategories.Where(q => q.DateDeleted == null).ToList();
        //}

        public async Task<Category?> GetCategoryById(Guid id)
        {
            var galleryCategory = await _context.Categories.FirstOrDefaultAsync(q => q.Id == id);
            return galleryCategory;
        }

        public async Task<Category?> GetCategoryByName(string name)
        {
            var galleryCategory = await _context.Categories.FirstOrDefaultAsync(q => q.Name == name && q.DateDeleted == null);
            return galleryCategory;
        }
    }
}
