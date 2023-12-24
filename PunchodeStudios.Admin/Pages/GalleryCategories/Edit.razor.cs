using Microsoft.AspNetCore.Components;
using PunchcodeStudios.Admin.Contracts;
using PunchcodeStudios.Admin.Models.Gallery;

namespace PunchcodeStudios.Admin.Pages.GalleryCategories
{
    public partial class Edit
    {
        public Edit()
        {
            Model = new GalleryCategoryViewModel();
        }
        public GalleryCategoryViewModel Model { get; set; }

        [Inject]
        public NavigationManager _navigationManager { get; set; }
        [Inject]
        private IGalleryCategoryService _service { get; set; }

        public string Message { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async void OnInitialized()
        {
            Model = await _service.GetGalleryCategoryById(new Guid(Id));
            StateHasChanged();
            base.OnInitialized();
        }

        private async void HandleValidSubmit()
        {

            if (await _service.UpdateGalleryCategory(Model) != null)
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
            Model = new GalleryCategoryViewModel();
            StateHasChanged();
        }
    }
}