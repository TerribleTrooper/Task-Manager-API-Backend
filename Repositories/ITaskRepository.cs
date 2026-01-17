using Task_Manager_API_Backend.Models.Entity;

namespace Task_Manager_API_Backend.Repositories;

public interface ITaskRepository
{
    Task<IEnumerable<TaskItem>> GetByUserIdAsync(Guid userId);
    Task AddAsync(TaskItem task);
    
    Task UpdateAsync(TaskItem task);
    Task DeleteAsync(TaskItem task);
    
    Task<TaskItem?> GetByIdAndUserIdAsync(Guid taskId, Guid userId);
}
