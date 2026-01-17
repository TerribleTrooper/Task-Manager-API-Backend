namespace Task_Manager_API_Backend.Services;

public interface IAuthService
{
    Task RegisterAsync(DTOs.RegisterUserDto dto);
    Task<string> LoginAsync(DTOs.LoginUserDto dto);
}