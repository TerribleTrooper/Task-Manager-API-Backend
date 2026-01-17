using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task_Manager_API_Backend.DTOs;
using Task_Manager_API_Backend.Extensions;
using Task_Manager_API_Backend.Models.Entity;
using Task_Manager_API_Backend.Services;

namespace Task_Manager_API_Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;
    
    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(CreateTaskDto dto)
    {
        var userId = User.GetUserId();
        await _taskService.CreateAsync(dto, userId);
        return Ok();
    }
    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetMyTasks()
    {
        var userId = User.GetUserId();
        var tasks = await _taskService.GetMyTasksAsync(userId);
        return Ok(tasks);
    }
    
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateTaskDto dto)
    {
        var userId = User.GetUserId();
        await _taskService.UpdateAsync(id, dto, userId);
        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userId = User.GetUserId();
        await _taskService.DeleteAsync(id, userId);
        return NoContent();
    }
}