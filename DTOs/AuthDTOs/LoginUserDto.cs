using System.ComponentModel.DataAnnotations;

namespace Task_Manager_API_Backend.DTOs;

public class LoginUserDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}