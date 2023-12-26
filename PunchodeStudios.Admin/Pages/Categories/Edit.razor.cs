using Microsoft.AspNetCore.Components;
using PunchcodeStudios.Admin.Contracts;
using PunchcodeStudios.Admin.Models.Gallery;

namespace PunchcodeStudios.Admin.Pages.Categories
{
    public partial class Edit
    {
        public Edit()
        {
            Model = new CategoryViewModel();
        }
        public CategoryViewModel Model { get; set; }

        [Inject]
        public NavigationManager _navigationManager { get; set; }
        [Inject]
        private ICategoryService _service { get; set; }

        public string Message { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async void OnInitialized()
        {
            Model = await _service.GetCategoryById(new Guid(Id));
            StateHasChanged();
            base.OnInitialized();
        }

        private async void HandleValidSubmit()
        {

            if (await _service.UpdateCategory(Model) != null)
            {
                _navigationManager.NavigateTo("/gallery-categories");
            }
            Message = "Error updating gallery";
        }

        void HandleInvalidSubmit()
        {
            Message = "Error updating gallery cateogry";
        }

        void OnCancel()
        {
            Model = new CategoryViewModel();
            StateHasChanged();
        }
    }
}