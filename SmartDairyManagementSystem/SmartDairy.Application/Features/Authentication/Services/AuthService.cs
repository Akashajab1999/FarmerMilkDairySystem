using SmartDairy.Application.Features.Authentication.DTOs;
using SmartDairy.Application.Features.Authentication.Interfaces;

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

    public Task<bool> RegisterAsync(RegisterRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<string?> LoginAsync(LoginRequest request)
    {
        throw new NotImplementedException();
    }
}