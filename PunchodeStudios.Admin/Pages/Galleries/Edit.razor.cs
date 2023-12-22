using Microsoft.AspNetCore.Components;
using PunchcodeStudios.Admin.Contracts;
using PunchcodeStudios.Admin.Models.Gallery;

namespace PunchcodeStudios.Admin.Pages.Galleries
{
    public partial class Edit
    {
        public Edit()
        {
            Model = new GalleryViewModel();
        }
        public GalleryViewModel Model { get; set; }

        [Inject]
        public NavigationManager _navigationManager { get; set; }
        [Inject]
        private IGalleryService _galleryService { get; set; }

        public string Message { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async void OnInitialized()
        {
            Model = await _galleryService.GetGalleryById(new Guid(Id));
            StateHasChanged();
            base.OnInitialized();
        }

        async void SubmitUpdate(GalleryViewModel args)
        {

            if (await _galleryService.UpdateGallery(args) != null)
            {
                _navigationManager.NavigateTo("/galleries");
            }
            Message = "Error updating gallery";
        }
    }
}