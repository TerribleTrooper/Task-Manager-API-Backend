using Task_Manager_API_Backend.Models.Entity;

namespace Task_Manager_API_Backend.Repositories;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task AddAsync(User user);
}
