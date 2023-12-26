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
        private ICategoryService _categoryService { get; set; }

        [Inject]
        private ICategoryGalleryService _categoryGalleryService { get; set; }

        public string Message { get; set; }

        [Parameter]
        public string Id { get; set; }

        public List<SelectOption> Options { get; set; } = new List<SelectOption>();

        public SelectOption Option { get; set; } = new SelectOption();
        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

        protected override async void OnInitialized()
        {
            Model = await _galleryService.GetGalleryById(new Guid(Id));
            Options = new List<SelectOption>();
            Categories = await _categoryService.GetCategories();

            foreach (var option in Categories)
            {
                Options.Add( new SelectOption { Text = option.Name, Value = option.Id.ToString(), Selected = false } );
            }
            Model.AvailableCategories = Options;

            StateHasChanged();
            base.OnInitialized();
        }

        async void SubmitUpdate(GalleryViewModel args)
        {
            foreach (var option in args.AvailableCategories.Where(a => a.Selected == true))
            {
                CategoryGalleryViewModel model = new CategoryGalleryViewModel()
                {
                    GalleriesId = new Guid(Id),
                    CategoriesId = new Guid(option.Value)
                };
                args.GalleryCategories.Add(model);
            }

            if (await _galleryService.UpdateGallery(args) != null)
            {
                _navigationManager.NavigateTo("/galleries");
            }
            Message = "Error updating gallery";
        }
    }
}