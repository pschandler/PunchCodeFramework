using Microsoft.AspNetCore.Components;
using PunchcodeStudios.Admin.Contracts;
using PunchcodeStudios.Admin.Models.Gallery;

namespace PunchcodeStudios.Admin.Pages.Galleries
{
    public partial class Details
    {
        public Details()
        {
            Gallery = new GalleryViewModel();
        }

        [Inject]
        public IGalleryService GalleryService { get; set; }

        public GalleryViewModel Gallery { get; set; }

        public string Message { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async void OnInitialized()
        {
            Gallery = await GalleryService.GetGalleryById(new Guid(Id));
            StateHasChanged();
            base.OnInitialized();
        }
    }
}