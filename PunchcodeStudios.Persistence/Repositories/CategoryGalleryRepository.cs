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
    public class CategoryGalleryRepository : GenericRepository<CategoryGallery>, ICategoryGalleryRepository
    {
        public CategoryGalleryRepository(PCStudioDbContext context) : base(context)
        {
        }
        public async Task<bool> AddGalleryToCategory(Guid galleryId, Guid categoryId)
        {
            CategoryGallery model = new CategoryGallery()
            {
                GalleriesId = galleryId,
                CategoriesId = categoryId
            };
            try
            {
                await _context.CategoryGalleries.AddAsync(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return false;
            }
            //throw new NotImplementedException();
        }

        public Task<bool> RemoveAllCategoriesFromGallery(Guid galleryId)
        {
            throw new NotImplementedException();
        }
    }
}
