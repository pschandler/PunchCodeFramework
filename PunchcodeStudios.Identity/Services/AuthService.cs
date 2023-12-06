using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PunchcodeStudios.Application.Contracts.Identity;
using PunchcodeStudios.Application.Exceptions;
using PunchcodeStudios.Application.Models.Identity;
using PunchcodeStudios.Identity.Models.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtSettings _jwtSettings;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(UserManager<ApplicationUser> userManager, 
            IOptions<JwtSettings> jwtSettings, 
            SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._jwtSettings = jwtSettings.Value;
            this._signInManager = signInManager;
        }


        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if(user == null) { throw new NotFoundException($"User with {request.Email} not found", request.Email); }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if(!result.Succeeded) { throw new BadRequestException($"Credentials for {request.Email} are not valid."); }

            JwtSecurityToken token = await GenerateToken(user);
            var response = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Email = user.Email,
                UserName = user.UserName
            };
            return response;
        }
        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if(result.Succeeded)
            {
                return new RegistrationResponse() { UserId = user.Id };
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach(var err in result.Errors)
                {
                    sb.AppendFormat("-{0}\n", err.Description);
                }
                throw new BadRequestException($"{sb}");
            }
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }.Union(userClaims).Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials
                );
            return jwtToken;
        }

    }
}
