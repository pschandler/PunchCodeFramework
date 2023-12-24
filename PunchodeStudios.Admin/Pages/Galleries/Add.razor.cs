using Microsoft.AspNetCore.Components;
using PunchcodeStudios.Admin.Contracts;
using PunchcodeStudios.Admin.Models.Gallery;

namespace PunchcodeStudios.Admin.Pages.Galleries
{
    public partial class Add
    {
        public Add()
        {
            Model = new GalleryViewModel();
        }

        [Parameter]
        public GalleryViewModel Model { get; set; }

        [Inject]
        public NavigationManager _navigationManager { get; set; }
        [Inject]
        private IGalleryService _galleryService { get; set; }

        public string Message { get; set; }

        protected override void OnInitialized()
        {
            Model = new GalleryViewModel();
            base.OnInitialized();
        }

        private async void HandleValidSubmit()
        {

            if (await _galleryService.CreateGallery(Model) != null)
            {
                _navigationManager.NavigateTo("/galleries");
            }
            Message = "Error creating gallery";
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
            this.Model = new GalleryViewModel();
            StateHasChanged();
        }
    }
}