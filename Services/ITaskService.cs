using Task_Manager_API_Backend.DTOs;

namespace Task_Manager_API_Backend.Services;

public interface ITaskService
{
    Task CreateAsync(CreateTaskDto dto, Guid userId);
    Task<IEnumerable<TaskResponseDto>> GetMyTasksAsync(Guid userId);
    Task UpdateAsync(Guid taskId, UpdateTaskDto dto, Guid userId);
    Task DeleteAsync(Guid taskId, Guid userId);

}
