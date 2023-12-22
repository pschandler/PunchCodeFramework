using System.ComponentModel.DataAnnotations;

namespace PunchcodeStudios.Admin.Models;

public class RegisterViewModel
{
    [Required]
    public string FirstName { get; set; } = string.Empty;

    public string? LastName { get; set; }

    [Required]
    public string Email { get; set; } = string.Empty;

    public string? UserName { get; set; }

    [Required]
    public string Password { get; set; } = string.Empty;
}
