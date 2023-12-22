using System.ComponentModel.DataAnnotations;

namespace PunchcodeStudios.Admin.Models;

public class LoginViewModel
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool IsGuest { get; set; }
    public string GuestLoginDisclaimer { get; set; } = string.Empty;
    public bool ShowLogin { get; set; }
    public bool ShowRegister { get; set; }
}
