using Microsoft.AspNetCore.Components;
using PunchcodeStudios.Admin.Contracts;
using PunchcodeStudios.Admin.Models.Gallery;

namespace PunchcodeStudios.Admin.Pages.GalleryCategories
{
    public partial class Add
    {
        public Add()
        {
            Model = new GalleryCategoryViewModel();
        }

        [Parameter]
        public GalleryCategoryViewModel Model { get; set; }

        [Inject]
        public NavigationManager _navigationManager { get; set; }
        [Inject]
        private IGalleryCategoryService _service { get; set; }

        public string Message { get; set; }

        protected override void OnInitialized()
        {
            Model = new GalleryCategoryViewModel();
            base.OnInitialized();
        }

        private async void HandleValidSubmit()
        {

            if (await _service.CreateGalleryCategory(Model) != null)
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
            this.Model = new GalleryCategoryViewModel();
            StateHasChanged();
        }
    }
}