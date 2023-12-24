using Microsoft.AspNetCore.Components;
using PunchcodeStudios.Admin.Contracts;
using PunchcodeStudios.Admin.Models.Gallery;
using PunchcodeStudios.UI.Components.Models;

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

        [Inject]
        private IGalleryCategoryService _categoryService { get; set; }

        public string Message { get; set; }

        [Parameter]
        public string Id { get; set; }

        public List<SelectOption> Options { get; set; } = new List<SelectOption>();

        public SelectOption Option { get; set; } = new SelectOption();
        public List<GalleryCategoryViewModel> GalleryCategories { get; set; } = new List<GalleryCategoryViewModel>();

        protected override async void OnInitialized()
        {
            Model = await _galleryService.GetGalleryById(new Guid(Id));
            Options = new List<SelectOption>();
            GalleryCategories = await _categoryService.GetGalleryCategories();

            foreach (var option in GalleryCategories)
            {
                Options.Add( new SelectOption { Text = option.Name, Value = option.Id.ToString(), Selected = false } );
            }
            Model.AvailableCategories = Options;

            StateHasChanged();
            base.OnInitialized();
        }

        async void SubmitUpdate(GalleryViewModel args)
        {

            if (await _galleryService.UpdateGallery(args) != null)
            {
                foreach (var option in args.AvailableCategories.Where(a => a.Selected == true))
                {
                    args.Categories.Add(await _categoryService.GetGalleryCategoryById(new Guid(option.Value)));
                }
                _navigationManager.NavigateTo("/galleries");
            }
            Message = "Error updating gallery";
        }
    }
}