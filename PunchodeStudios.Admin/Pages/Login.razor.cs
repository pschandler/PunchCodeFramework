using Microsoft.AspNetCore.Components;
using PunchcodeStudios.Admin.Contracts;
using PunchcodeStudios.Admin.Models;
using Radzen;

namespace PunchcodeStudios.Admin.Pages
{
    public partial class Login
    {
        public LoginViewModel Model { get; set; }
        public RegisterViewModel Register { get; set; }

        [Inject]
        public NavigationManager _navigationManager { get; set; }
        [Inject]
        private IAuthenticationService _authenticationService { get; set; }

        public string Message { get; set; }

        protected override void OnInitialized()
        {
            Model = new LoginViewModel();
            Register = new RegisterViewModel();
            Model.ShowRegister = false;
            Model.ShowLogin = true;
            base.OnInitialized();
        }


        protected async Task SubmitLogin(LoginArgs args)
        {
            var username = Model.IsGuest ? "noreply@punchcodestudios.com" : args.Username;
            var password = Model.IsGuest ? "Dragon8473" : args.Password;
            var rememberMe = args.RememberMe;
            if (await _authenticationService.AuthenticateAsync(username, password))
            {
                _navigationManager.NavigateTo("/");
            }
            Message = "Unknown username or password.";
        }

        protected void HandleRegister()
        {
            Model.ShowRegister = true;
            Model.ShowLogin = false;
            Message = "Navigating to Register";
        }

        protected void HandleLogin()
        {
            Model.ShowRegister = false;
            Model.ShowLogin = true;
            Message = "Navigating to Login";
        }

        void SubmitRegister(RegisterViewModel args )
        {
            //if(await _authenticationService.RegisterAsync(args.Model.FirstName, args.Model.LastName, args.Model.UserName, args.Model.Email, args.Model.Password))
            //{
            //    _navigationManager.NavigateTo("/");
            //}
            Message = "Unable to register";
        }

        protected void HandleResetPassword()
        {
            //_navigationManager.NavigateTo("/reset-password");
            Message = "Navigating to Reset Password";
        }

    }
}