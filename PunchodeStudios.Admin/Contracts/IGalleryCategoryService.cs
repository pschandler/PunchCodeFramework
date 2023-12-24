using PunchcodeStudios.Admin.Models.Gallery;
using PunchcodeStudios.Admin.Services.Base;

namespace PunchcodeStudios.Admin.Contracts
{
    public interface IGalleryCategoryService
    {
        Task<List<GalleryCategoryViewModel>> GetGalleryCategories();
        Task<GalleryCategoryViewModel> GetGalleryCategoryById(Guid id);
        Task<GalleryCategoryViewModel> GetGalleryCategoryByName(string name);
        Task<ApiResponse<Guid>> CreateGalleryCategory(GalleryCategoryViewModel model);
        Task<ApiResponse<Guid>> UpdateGalleryCategory(GalleryCategoryViewModel model);
        Task<ApiResponse<Guid>> DeleteGalleryCategory(Guid id);
    }
}
