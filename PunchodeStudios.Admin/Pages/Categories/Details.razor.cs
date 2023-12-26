using Microsoft.AspNetCore.Components;
using PunchcodeStudios.Admin.Contracts;
using PunchcodeStudios.Admin.Models.Gallery;

namespace PunchcodeStudios.Admin.Pages.Categories
{
    public partial class Details
    {
        public Details()
        {
            Model = new CategoryViewModel();
        }

        [Inject]
        public ICategoryService service { get; set; }

        public CategoryViewModel Model { get; set; }

        public string Message { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async void OnInitialized()
        {
            Model = await service.GetCategoryById(new Guid(Id));
            StateHasChanged();
            base.OnInitialized();
        }
    }
}