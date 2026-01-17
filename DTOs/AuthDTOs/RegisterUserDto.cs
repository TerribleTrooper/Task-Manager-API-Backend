using System.ComponentModel.DataAnnotations;

namespace Task_Manager_API_Backend.DTOs;
public class RegisterUserDto 
{
    [Required]
    [EmailAddress] // — это атрибут валидации данных из System.ComponentModel.DataAnnotations.
    public string Email { get; set; } = null!;

    [Required]
    [MinLength(6)]
    public string Password { get; set; } = null!;
}