using Microsoft.AspNetCore.Components;
using PunchcodeStudios.Admin.Contracts;
using PunchcodeStudios.Admin.Models;

namespace PunchcodeStudios.Admin.Pages
{
    public partial class Register
    {
        public RegisterViewModel Model { get; set; }

        [Inject]
        public NavigationManager _navigationManager { get; set; }
        [Inject]
        private IAuthenticationService _authenticationService { get; set; }

        public string Message { get; set; }

        protected override void OnInitialized()
        {
            Model = new RegisterViewModel();
            base.OnInitialized();
        }

        protected async Task HandleRegister()
        {
            var result = await _authenticationService.RegisterAsync(Model.FirstName, Model.LastName ?? string.Empty, Model.UserName ?? Model.Email, Model.Email, Model.Password);
            if (result)
            {
                _navigationManager.NavigateTo("/");
            }
            Message = "Something went wrong";
        }
    }
}