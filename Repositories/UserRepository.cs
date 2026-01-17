using Microsoft.EntityFrameworkCore;
using Task_Manager_API_Backend.Data;
using Task_Manager_API_Backend.Models.Entity;

namespace Task_Manager_API_Backend.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TaskDbContext _context;

    public UserRepository(TaskDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        email = email.Trim().ToLower();

        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);
    }


    public async Task AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}
