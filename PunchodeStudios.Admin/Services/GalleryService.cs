using AutoMapper;
using PunchodeStudios.Admin.Contracts;
using PunchodeStudios.Admin.Models.Gallery;
using PunchodeStudios.Admin.Services.Base;

namespace PunchodeStudios.Admin.Services
{
    public class GalleryService  : BaseHttpService, IGalleryService
    {
        private readonly IMapper _mapper;

        public GalleryService(IClient client, IMapper mapper) : base(client)
        {
            this._mapper = mapper;
        }
        public async Task<List<GalleryViewModel>> GetGalleries()
        {
            var galleries = await _client.GalleryAllAsync();
            return _mapper.Map<List<GalleryViewModel>>(galleries);
        }

        public async Task<GalleryViewModel> GetGalleryById(Guid id)
        {
            var gallery = await _client.IdAsync(id);
            return _mapper.Map<GalleryViewModel>(gallery);
        }

        public async  Task<GalleryViewModel> GetGalleryByName(string name)
        {
            var gallery = await _client.NameAsync(name);
            return _mapper.Map<GalleryViewModel>(gallery);
        }


        public async Task<ApiResponse<Guid>> CreateGallery(GalleryViewModel model)
        {
            try
            {
                var createGalleryCommand = _mapper.Map<CreateGalleryCommand>(model);
                Guid id = await _client.GalleryPOSTAsync(createGalleryCommand);
                return new ApiResponse<Guid>()
                {
                    Success = true,
                    Data = id,
                    Message = "Gallery created successfully.",
                };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
        public async Task<ApiResponse<Guid>> UpdateGallery(GalleryViewModel model)
        {
            try
            {
                var updateGalleryCommand = _mapper.Map<UpdateGalleryCommand>(model);
                await _client.GalleryPUTAsync(updateGalleryCommand);
                return new ApiResponse<Guid>()
                {
                    Success = true,
                    Message = "Gallery Updated Successfully."
                };
            }
            catch(ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ApiResponse<Guid>> DeleteGallery(Guid id)
        {
            try
            {
                bool response = await _client.GalleryDELETEAsync(id);
                return new ApiResponse<Guid>()
                {
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

    }
}
