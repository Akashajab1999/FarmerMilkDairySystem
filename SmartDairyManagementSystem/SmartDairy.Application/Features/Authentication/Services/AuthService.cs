using SmartDairy.Application.Features.Authentication.DTOs;
using SmartDairy.Application.Features.Authentication.Interfaces;
using SmartDairy.Domain.Entities;

namespace SmartDairy.Application.Features.Authentication.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;

    public AuthService(
        IUserRepository userRepository,
        IJwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<bool> RegisterAsync(RegisterRequest request)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);

        if (existingUser != null)
            return false;

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            MobileNumber = request.MobileNumber,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Role = "Admin",
            IsActive = true
        };

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        return true;
    }

    public Task<string?> LoginAsync(LoginRequest request)
    {
        throw new NotImplementedException();
    }
}