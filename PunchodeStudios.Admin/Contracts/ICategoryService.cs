using PunchcodeStudios.Admin.Models.Gallery;
using PunchcodeStudios.Admin.Services.Base;

namespace PunchcodeStudios.Admin.Contracts
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetCategories();
        Task<CategoryViewModel> GetCategoryById(Guid id);
        Task<CategoryViewModel> GetCategoryByName(string name);
        Task<ApiResponse<Guid>> CreateCategory(CategoryViewModel model);
        Task<ApiResponse<Guid>> UpdateCategory(CategoryViewModel model);
        Task<ApiResponse<Guid>> DeleteCategory(Guid id);
    }
}
