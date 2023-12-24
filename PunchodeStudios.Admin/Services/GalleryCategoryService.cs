using AutoMapper;
using Blazored.LocalStorage;
using PunchcodeStudios.Admin.Contracts;
using PunchcodeStudios.Admin.Models.Gallery;
using PunchcodeStudios.Admin.Services.Base;
using Radzen.Blazor.Rendering;

namespace PunchcodeStudios.Admin.Services
{
    public class GalleryCategoryService : BaseHttpService, IGalleryCategoryService
    {
        private readonly IMapper _mapper;
        public GalleryCategoryService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            this._mapper = mapper;
        }
        public async Task<List<GalleryCategoryViewModel>> GetGalleryCategories()
        {
            await AddBearerToken();
            var items = await _client.GalleryCategoryAllAsync();
            return _mapper.Map<List<GalleryCategoryViewModel>>(items);
        }
        public async Task<GalleryCategoryViewModel> GetGalleryCategoryById(Guid id)
        {
            await AddBearerToken();
            var item = await _client.Id2Async(id);
            return _mapper.Map<GalleryCategoryViewModel>(item);
        }

        public async Task<GalleryCategoryViewModel> GetGalleryCategoryByName(string name)
        {
            await AddBearerToken();
            var item = await _client.Name2Async(name);
            return _mapper.Map<GalleryCategoryViewModel>(item);
        }

        public async Task<ApiResponse<Guid>> CreateGalleryCategory(GalleryCategoryViewModel model)  
        {
            try
            {
                await AddBearerToken();
                var cmd = _mapper.Map<CreateGalleryCategoryCommand>(model);
                Guid id = await _client.GalleryCategoryPOSTAsync(cmd);
                return new ApiResponse<Guid>()
                {
                    Success = true,
                    Data = id,
                    Message = "Gallery Category created successfully.",
                };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
        public async Task<ApiResponse<Guid>> UpdateGalleryCategory(GalleryCategoryViewModel model)
        {
            try
            {
                await AddBearerToken();
                var cmd = _mapper.Map<UpdateGalleryCategoryCommand>(model);
                await _client.GalleryCategoryPUTAsync(cmd);
                return new ApiResponse<Guid>()
                {
                    Success = true,
                    Message = "Gallery Category Updated Successfully."
                };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ApiResponse<Guid>> DeleteGalleryCategory(Guid id)
        {
            try
            {
                await AddBearerToken();
                bool response = await _client.GalleryCategoryDELETEAsync(id);
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
