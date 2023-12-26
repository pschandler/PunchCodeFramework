using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PunchcodeStudios.Application.Contracts.Persisitence;
using PunchcodeStudios.Domain;
using PunchcodeStudios.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Persistence.Repositories
{
    public class GalleryRepository : GenericRepository<Gallery>, IGalleryRepository
    {
        public GalleryRepository(PCStudioDbContext context) : base(context)
        {
            
        }

        public async Task<bool> GalleryIsUnique(string name, bool includeDeleted = false)
        {
            return includeDeleted
                ? await _context.Galleries.AnyAsync(q => q.Name == name) 
                : await _context.Galleries.AnyAsync(q => q.Name == name && q.DateDeleted == null);
        }

        public async Task<bool> GalleryExists(Guid Id, bool includeDeleted = false)
        {
            return includeDeleted
                ? await _context.Galleries.AnyAsync(q => q.Id == Id)
                : await _context.Galleries.AnyAsync(q => q.Id == Id && q.DateDeleted == null);
        }

        public async Task<Gallery?> GetGalleryByName(string name)
        {
            var gallery = await _context.Galleries
                .Include(q => q.Categories)
                .Include(q => q.Type)
                .FirstOrDefaultAsync(q => q.Name == name && q.DateDeleted == null);
            return gallery;
        }

        //public async Task<IReadOnlyList<Gallery>> GetAllGalleries(bool includeDeleted = false)
        //{
        //    var galleries = await _context.Galleries
        //        .Include(q => q.Category)
        //        .Include(q => q.Type)
        //        .ToListAsync();
        //    return includeDeleted 
        //        ? galleries 
        //        : galleries.Where(q => q.DateDeleted == null).ToList();
        //}

        //public async Task<IReadOnlyList<Gallery>> GetGalleryByCategory(Guid categoryId, bool includeDeleted = false)
        //{
        //    var galleries = await _context.Galleries
        //        .Where(q => q.CategoryId == categoryId)
        //        .Include(q => q.Category)
        //        .Include(q => q.Type)
        //        .ToListAsync();
        //    return includeDeleted
        //        ? galleries
        //        : galleries.Where(q => q.DateDeleted == null).ToList();
        //}

        //public async Task<IReadOnlyList<Gallery>> GetGalleryByType(Guid typeId, bool includeDeleted = false)
        //{
        //    var galleries = await _context.Galleries
        //        .Where(q => q.GalleryTypeId == typeId)
        //        .Include(q => q.Category)
        //        .Include(q => q.Type)
        //        .ToListAsync();
        //    return includeDeleted
        //        ? galleries
        //        : galleries.Where(q => q.DateDeleted == null).ToList();
        //}

        //public async Task<Gallery?> GetGallerylById(Guid id)
        //{
        //    var gallery = await _context.Galleries
        //        .Include(q => q.Category)
        //        .Include(q => q.Type)
        //        .FirstOrDefaultAsync(q => q.Id == id);
        //    return gallery;
        //}



        //public async Task<IReadOnlyList<Gallery>> GetGalleriesByTypeId(Guid typeId, bool includeDeleted = false)
        //{
        //    var galleries = await _context.Galleries
        //        .Include(q => q.Categories)
        //        .Include(q => q.Types)
        //        .Where(q => q.Type != null && q.GalleryTypeId == typeId)
        //        .ToListAsync();
        //    return galleries;
        //}

        //public async Task<IReadOnlyList<Gallery>> GetGalleriesByTypeName(string typeName, bool includeDeleted = false)
        //{
        //    var galleries = await _context.Galleries
        //        .Include(q => q.Category)
        //        .Include(q => q.Type)
        //        .Where(q => q.Type != null && q.Type.Name == typeName)
        //        .ToListAsync();
        //    return galleries;
        //}

        //public async Task<IReadOnlyList<Gallery>> GetGalleriesByCategoryId(Guid categoryId, bool includeDeleted = false)
        //{
        //    var galleries = await _context.Galleries
        //        .Include(q => q.Category)
        //        .Include(q => q.Type)
        //        .Where(q => q.Category != null && q.CategoryId == categoryId)
        //        .ToListAsync();
        //    return galleries;
        //}

        //public async Task<IReadOnlyList<Gallery>> GetGalleriesByCategoryName(string categoryName, bool includeDeleted = false)
        //{
        //    var galleries = await _context.Galleries
        //        .Include(q => q.Category)
        //        .Include(q => q.Type)
        //        .Where(q => q.Category != null && q.Category.Name == categoryName)
        //        .ToListAsync();
        //    return galleries;
        //}
    }
}
