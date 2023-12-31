using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using PunchcodeStudios.Admin.Contracts;
using PunchcodeStudios.Admin.Models.Gallery;

namespace PunchcodeStudios.Admin.Pages.Categories
{
    public partial class Index
    {
        [Inject]
        IToastService _toastService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ICategoryService Service { get; set; }

        public List<CategoryViewModel> Model { get; set; }
        public string Message { get; set; }

        protected void Add()
        {
            NavigationManager.NavigateTo($"/gallery-category/add/");
        }

        protected void Details(Guid id)
        {
            NavigationManager.NavigateTo($"/gallery-category-details/{id}");
        }

        protected void Edit(Guid id)
        {
            NavigationManager.NavigateTo($"/gallery-category/edit/{id}");
        }

        public void Submit()
        {
            _toastService.ShowWarning("LOGIN");
        }

        protected async void Delete(Guid id)
        {
            var response = await Service.DeleteCategory(id);
            if (response.Success)
            {
                _toastService.ShowSuccess("Gallery Category Deleted");
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
            Model = await Service.GetCategories();
            _toastService.ShowSuccess("Gallery Categories Successfully retrieved.");
            StateHasChanged();
        }
    }
}