using Microsoft.AspNetCore.Identity;
using PunchcodeStudios.Application.Contracts.Identity;
using PunchcodeStudios.Application.Models.Identity;
using PunchcodeStudios.Identity.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Identity.Services
{
    // TODO: AutoMapper for users??
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }
        public async Task<List<User>> GetUsers()
        {
            var users = await _userManager.GetUsersInRoleAsync("Admin");
            return users.Select(q => new User
            {
                Id = q.Id,
                Email = q.Email,
                FirstName = q.FirstName,
                LastName = q.LastName
            }).ToList();
        }

        public async Task<User> GetUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return new User
            {
                Email = user.Email,
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
    }
}
