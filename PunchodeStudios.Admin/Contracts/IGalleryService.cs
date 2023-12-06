using PunchodeStudios.Admin.Models.Gallery;
using PunchodeStudios.Admin.Services.Base;

namespace PunchodeStudios.Admin.Contracts
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
