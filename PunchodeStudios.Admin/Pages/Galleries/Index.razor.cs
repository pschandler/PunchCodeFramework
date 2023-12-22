using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using PunchcodeStudios.Admin.Contracts;
using PunchcodeStudios.Admin.Models.Gallery;
using PunchcodeStudios.Admin.Services.Base;

namespace PunchcodeStudios.Admin.Pages.Galleries
{
    public partial class Index
    {
        [Inject]
        IToastService _toastService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IGalleryService GalleryService { get; set; }

        public List<GalleryViewModel> Galleries { get; set; }
        public string Message { get; set; }

        protected void AddGallery()
        {
            NavigationManager.NavigateTo($"/gallery/add/");
        }

        protected void GalleryDetails(Guid id) 
        {
            NavigationManager.NavigateTo($"/details/{id}");
        }

        protected void GalleryEdit(Guid id)
        {
            NavigationManager.NavigateTo($"/gallery/edit/{id}");
        }

        public void Submit()
        {
            _toastService.ShowWarning("LOGIN");
        }

        protected async void GalleryDelete(Guid id)
        {
            var response = await GalleryService.DeleteGallery(id);
            if(response.Success)
            {
                _toastService.ShowSuccess("Gallery Deleted");
                StateHasChanged();
            }
            else
            {
                _toastService.ShowError(Message);
            }
        }

        protected override async void OnInitialized()
        {
            base.OnInitialized();
            Galleries = await GalleryService.GetGalleries();
            _toastService.ShowSuccess("Galleries Successfully retrieved.");
            StateHasChanged();
        }
    }
}