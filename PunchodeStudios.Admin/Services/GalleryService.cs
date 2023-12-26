using AutoMapper;
using Blazored.LocalStorage;
using PunchcodeStudios.Admin.Contracts;
using PunchcodeStudios.Admin.Models.Gallery;
using PunchcodeStudios.Admin.Services.Base;

namespace PunchcodeStudios.Admin.Services
{
    public class GalleryService  : BaseHttpService, IGalleryService
    {
        private readonly IMapper _mapper;

        public GalleryService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            this._mapper = mapper;
        }
        public async Task<List<GalleryViewModel>> GetGalleries()
        {
            await AddBearerToken();
            var galleries = await _client.GalleryAllAsync();
            return _mapper.Map<List<GalleryViewModel>>(galleries);
        }

        public async Task<GalleryViewModel> GetGalleryById(Guid id)
        {
            await AddBearerToken();
            var gallery = await _client.Id2Async(id);
            return _mapper.Map<GalleryViewModel>(gallery);
        }

        public async  Task<GalleryViewModel> GetGalleryByName(string name)
        {
            await AddBearerToken();
            var gallery = await _client.NameAsync(name);
            return _mapper.Map<GalleryViewModel>(gallery);
        }


        public async Task<ApiResponse<Guid>> CreateGallery(GalleryViewModel model)
        {
            try
            {
                await AddBearerToken();
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
                await AddBearerToken();
                var updateGalleryCommand = _mapper.Map<UpdateGalleryCommand>(model);
                
                //await _client.GalleryPUTAsync(updateGalleryCommand);

                foreach(var item in model.GalleryCategories)
                {
                    var addCategoryToGalleryCommand = _mapper.Map<AddGalleryToCategoryCommand>(item);
                    await _client.GalleryCategoryAsync(addCategoryToGalleryCommand);
                }
                
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
                await AddBearerToken();
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
