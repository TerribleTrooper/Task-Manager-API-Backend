using Microsoft.AspNetCore.Identity;
using Task_Manager_API_Backend.DTOs;
using Task_Manager_API_Backend.Exceptions;
using Task_Manager_API_Backend.Models.Entity;
using Task_Manager_API_Backend.Repositories;

namespace Task_Manager_API_Backend.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly PasswordHasher<User> _passwordHasher;
    private readonly IJwtService _jwtService;

    public AuthService(
        IUserRepository userRepository,
        PasswordHasher<User> passwordHasher,
        IJwtService jwtService
    )
    
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
    }

    public async Task RegisterAsync(RegisterUserDto dto)
    {
        var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
        if (existingUser != null)
            throw new Exception("User already exists");

        var user = new User { Email = dto.Email };
        user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

        await _userRepository.AddAsync(user);
    }
    
    public async Task<string> LoginAsync(LoginUserDto dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email); // Достаём user 

        if (user == null)
            throw new UnauthorizedException("Invalid credentials");

        var result = _passwordHasher.VerifyHashedPassword(
            user,
            user.PasswordHash,
            dto.Password
        );

        if (result == PasswordVerificationResult.Failed)
            throw new UnauthorizedException("Invalid credentials");
        
        return _jwtService.GenerateToken(user);
    }
}