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
        public IGalleryService _service { get; set; }

        public List<GalleryViewModel> Model { get; set; }
        public string Message { get; set; }

        protected void Add()
        {
            NavigationManager.NavigateTo($"/gallery/add/");
        }

        protected void Details(Guid id) 
        {
            NavigationManager.NavigateTo($"/details/{id}");
        }

        protected void Edit(Guid id)
        {
            NavigationManager.NavigateTo($"/gallery/edit/{id}");
        }

        public void Submit()
        {
            _toastService.ShowWarning("LOGIN");
        }

        protected async void Delete(Guid id)
        {
            var response = await _service.DeleteGallery(id);
            if(response.Success)
            {
                Model = await _service.GetGalleries();
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
            Model = await _service.GetGalleries();
            _toastService.ShowSuccess("Galleries Successfully retrieved.");
            StateHasChanged();
        }
    }
}