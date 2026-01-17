using Task_Manager_API_Backend.DTOs;
using Task_Manager_API_Backend.Exceptions;
using Task_Manager_API_Backend.Models.Entity;
using Task_Manager_API_Backend.Repositories;
using Task_Manager_API_Backend.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task CreateAsync(CreateTaskDto dto, Guid userId)
    {
        var task = new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description,
            UserId = userId
        };

        await _taskRepository.AddAsync(task);
    }

    public async Task<IEnumerable<TaskResponseDto>> GetMyTasksAsync(Guid userId)
    {
        var tasks = await _taskRepository.GetByUserIdAsync(userId);

        return tasks.Select(t => new TaskResponseDto
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description,
            IsCompleted = t.IsCompleted
        });
    }
    
    public async Task UpdateAsync(Guid taskId, UpdateTaskDto dto, Guid userId)
    {
        var task = await _taskRepository.GetByIdAndUserIdAsync(taskId, userId);

        if (task == null)
            throw new NotFoundException("Task not found");

        task.Title = dto.Title;
        task.Description = dto.Description;
        task.IsCompleted = dto.IsCompleted;

        await _taskRepository.UpdateAsync(task);
    }
    
    public async Task DeleteAsync(Guid taskId, Guid userId)
    {
        var task = await _taskRepository.GetByIdAndUserIdAsync(taskId, userId);

        if (task == null)
            throw new NotFoundException("Task not found");

        await _taskRepository.DeleteAsync(task);
    }

}