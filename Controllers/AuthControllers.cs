using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task_Manager_API_Backend.DTOs;
using Task_Manager_API_Backend.Services;

namespace Task_Manager_API_Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthControllers : ControllerBase
{
    private readonly IAuthService _authService; // Это ссылка на объект класса, который реализует интерфейс.
    private readonly ITaskService _taskService;
    
    public AuthControllers(IAuthService authService,  ITaskService taskService)
    {
        _authService = authService;
        _taskService = taskService;
        
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] DTOs.RegisterUserDto dto)
    {
        await _authService.RegisterAsync(dto);
        return Ok("User registered successfully");
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(DTOs.LoginUserDto dto)
    {
        var token = await _authService.LoginAsync(dto);

        return Ok(new
        {
            access_token = token
        });
    }
}