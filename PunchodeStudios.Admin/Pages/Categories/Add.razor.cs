using Microsoft.AspNetCore.Components;
using PunchcodeStudios.Admin.Contracts;
using PunchcodeStudios.Admin.Models.Gallery;

namespace PunchcodeStudios.Admin.Pages.Categories
{
    public partial class Add
    {
        public Add()
        {
            Model = new CategoryViewModel();
        }

        [Parameter]
        public CategoryViewModel Model { get; set; }

        [Inject]
        public NavigationManager _navigationManager { get; set; }
        [Inject]
        private ICategoryService _service { get; set; }

        public string Message { get; set; }

        protected override void OnInitialized()
        {
            Model = new CategoryViewModel();
            base.OnInitialized();
        }

        private async void HandleValidSubmit()
        {

            if (await _service.CreateCategory(Model) != null)
            {
                _navigationManager.NavigateTo("/gallery-categories");
            }
            Message = "Error creating gallery category";
        }

        private void HandleInvalidSubmit()
        {

            //if (await _galleryService.CreateGallery(Model) != null)
            //{
            //    _navigationManager.NavigateTo("/galleries");
            //}
            Message = "Error creating gallery";
        }

        public void OnCancel()
        {
            this.Model = new CategoryViewModel();
            StateHasChanged();
        }
    }
}