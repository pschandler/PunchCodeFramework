using Microsoft.AspNetCore.Components;
using PunchodeStudios.Admin.Contracts;
using PunchodeStudios.Admin.Models.Gallery;
using PunchodeStudios.Admin.Services.Base;

namespace PunchodeStudios.Admin.Pages.Galleries
{
    public partial class Index
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IGalleryService GalleryService { get; set; }

        public List<GalleryViewModel> Galleries { get; set; }
        public string Message { get; set; }

        protected void CreateGallery()
        {
            NavigationManager.NavigateTo($"/galleries/create/");
        }

        protected void GalleryDetails(Guid id) 
        {
            NavigationManager.NavigateTo($"/gallery/{id}");
        }

        protected void GalleryEdit(Guid id)
        {
            NavigationManager.NavigateTo($"/galleries/edit/{id}");
        }

        protected async void GalleryDelete(Guid id)
        {
            var response = await GalleryService.DeleteGallery(id);
            if(response.Success)
            {
                StateHasChanged();
            }
            else
            {
                Message = response.Message;
            }
        }

        protected override async void OnInitialized()
        {
            Galleries = await GalleryService.GetGalleries();
            base.OnInitialized();
        }
    }
}