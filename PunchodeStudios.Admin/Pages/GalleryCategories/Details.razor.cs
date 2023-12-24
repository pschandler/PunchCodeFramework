using Microsoft.AspNetCore.Components;
using PunchcodeStudios.Admin.Contracts;
using PunchcodeStudios.Admin.Models.Gallery;

namespace PunchcodeStudios.Admin.Pages.GalleryCategories
{
    public partial class Details
    {
        public Details()
        {
            Model = new GalleryCategoryViewModel();
        }

        [Inject]
        public IGalleryCategoryService service { get; set; }

        public GalleryCategoryViewModel Model { get; set; }

        public string Message { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async void OnInitialized()
        {
            Model = await service.GetGalleryCategoryById(new Guid(Id));
            StateHasChanged();
            base.OnInitialized();
        }
    }
}