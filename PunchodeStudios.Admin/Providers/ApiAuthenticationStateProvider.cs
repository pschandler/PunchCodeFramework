using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PunchcodeStudios.Admin.Providers
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public ApiAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            this._localStorage = localStorage;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        // this method is checked regularly by Blazor runtime
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // no token
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            var isTokenPresent = await _localStorage.ContainKeyAsync("token");
            if(isTokenPresent == false)
            {
                return new AuthenticationState(user);
            }

            // token present, read it
            var savedToken = await _localStorage.GetItemAsync<string>("token");
            var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(savedToken);

            
            if (tokenContent.ValidTo < DateTime.Now)
            {
                // expired, remove and set state
                await _localStorage.RemoveItemAsync("token");
                return new AuthenticationState(user);
            }

            // set valid user
            var claims = await GetClaims();
            user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            return new AuthenticationState(user);   
        }

        public async Task LoggedIn()
        {
            var claims = await GetClaims();
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            var authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }
        public async Task LoggedOut()
        {
            await _localStorage.RemoveItemAsync("token");
            var loggedOutUser = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(loggedOutUser));
            NotifyAuthenticationStateChanged(authState);
        }
        private async Task<List<Claim>> GetClaims()
        {
            var savedToken = await _localStorage.GetItemAsync<string>("token");
            var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(savedToken);
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
            return claims;
        }
    }
}
