using PunchcodeStudios.Admin.Models.Gallery;
using PunchcodeStudios.Admin.Services.Base;

namespace PunchcodeStudios.Admin.Contracts
{
    public interface IGalleryService
    {
        Task<List<GalleryViewModel>> GetGalleries();
        Task<GalleryViewModel> GetGalleryById(Guid id);
        Task<GalleryViewModel> GetGalleryByName(string name);
        Task<ApiResponse<Guid>> CreateGallery(GalleryViewModel model);
        Task<ApiResponse<Guid>> UpdateGallery(GalleryViewModel model);
        Task<ApiResponse<Guid>> DeleteGallery(Guid id);
    }
}
