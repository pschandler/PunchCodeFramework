using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PunchcodeStudios.Admin.Contracts;
using PunchcodeStudios.Admin.Providers;
using PunchcodeStudios.Admin.Services.Base;
using System.ComponentModel.DataAnnotations;

namespace PunchcodeStudios.Admin.Services
{
    public class AuthenticationService : BaseHttpService, IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthenticationService(IClient client, 
            ILocalStorageService localStorage, 
            AuthenticationStateProvider authenticationStateProvider) 
        : base(client, localStorage)
        {
            this._authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            try
            {
                AuthRequest authenticationRequest = new AuthRequest()
                {
                    Email = email,
                    Password = password
                };
                var authenticationResponse =  await _client.LoginAsync(authenticationRequest);
                if(authenticationResponse.Token != string.Empty) {
                    await _localStorage.SetItemAsync("token", authenticationResponse.Token);
                    // TODO: set claims in Blazor and login state
                    await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                //_logger.LogError(ex);
                return false;
            }
        }

        public async Task Logout()
        {
            await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
        }

        public async Task<bool> RegisterAsync(string firstName, string lastName, string username, string email, string password)
        {
            RegistrationRequest registrationRequest = new RegistrationRequest()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = username,
                Password = password
            };
            var response = await _client.RegisterAsync(registrationRequest);
            if(!string.IsNullOrEmpty(response.UserId))
            {
                return true;
            }

            return false;
        }
    }
}
