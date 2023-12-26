using PunchcodeStudios.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Contracts.Persisitence
{
    public interface ICategoryGalleryRepository : IGenericRepository<CategoryGallery>
    {
        Task<bool> AddGalleryToCategory(Guid galleryId, Guid categoryId);
        //Task<bool> RemoveAllCategoriesFromGallery(Guid galleryId);
    }
}
