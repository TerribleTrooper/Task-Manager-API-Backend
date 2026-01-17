using Microsoft.EntityFrameworkCore;
using Task_Manager_API_Backend.Data;
using Task_Manager_API_Backend.Models.Entity;

namespace Task_Manager_API_Backend.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly TaskDbContext _context;

    public TaskRepository(TaskDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TaskItem>> GetByUserIdAsync(Guid userId)
    {
        return await _context.TaskItems
            .Where(t => t.UserId == userId)
            .ToListAsync();
    }

    public async Task AddAsync(TaskItem task)
    {
        _context.TaskItems.Add(task);
        await _context.SaveChangesAsync();
    }
    
    public async Task<TaskItem?> GetByIdAndUserIdAsync(Guid taskId, Guid userId)
    {
        return await _context.TaskItems
            .FirstOrDefaultAsync(t => t.Id == taskId && t.UserId == userId);
    }

    public async Task UpdateAsync(TaskItem task)
    {
        _context.TaskItems.Update(task);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TaskItem task)
    {
        _context.TaskItems.Remove(task);
        await _context.SaveChangesAsync();
    }

}
