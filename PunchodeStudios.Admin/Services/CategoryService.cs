using AutoMapper;
using Blazored.LocalStorage;
using PunchcodeStudios.Admin.Contracts;
using PunchcodeStudios.Admin.Models.Gallery;
using PunchcodeStudios.Admin.Services.Base;
using Radzen.Blazor.Rendering;

namespace PunchcodeStudios.Admin.Services
{
    public class CategoryService : BaseHttpService, ICategoryService
    {
        private readonly IMapper _mapper;
        public CategoryService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            this._mapper = mapper;
        }
        public async Task<List<CategoryViewModel>> GetCategories()
        {
            await AddBearerToken();
            var items = await _client.CategoryAllAsync();
            return _mapper.Map<List<CategoryViewModel>>(items);
        }
        public async Task<CategoryViewModel> GetCategoryById(Guid id)
        {
            await AddBearerToken();
            var item = await _client.Id2Async(id);
            return _mapper.Map<CategoryViewModel>(item);
        }

        public async Task<CategoryViewModel> GetCategoryByName(string name)
        {
            await AddBearerToken();
            var item = await _client.Name2Async(name);
            return _mapper.Map<CategoryViewModel>(item);
        }

        public async Task<ApiResponse<Guid>> CreateCategory(CategoryViewModel model)  
        {
            try
            {
                await AddBearerToken();
                var cmd = _mapper.Map<CreateCategoryCommand>(model);
                Guid id = await _client.CategoryPOSTAsync(cmd);
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
        public async Task<ApiResponse<Guid>> UpdateCategory(CategoryViewModel model)
        {
            try
            {
                await AddBearerToken();
                var cmd = _mapper.Map<UpdateCategoryCommand>(model);
                await _client.CategoryPUTAsync(cmd);
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

        public async Task<ApiResponse<Guid>> DeleteCategory(Guid id)
        {
            try
            {
                await AddBearerToken();
                bool response = await _client.CategoryDELETEAsync(id);
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
