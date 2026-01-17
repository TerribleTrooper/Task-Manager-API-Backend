using Task_Manager_API_Backend.Models.Entity;

namespace Task_Manager_API_Backend.Services;

public interface IJwtService
{
    string GenerateToken(User user);
}