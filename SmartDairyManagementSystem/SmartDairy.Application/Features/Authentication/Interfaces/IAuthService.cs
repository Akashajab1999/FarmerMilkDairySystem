using SmartDairy.Application.Features.Authentication.DTOs;

namespace SmartDairy.Application.Features.Authentication.Interfaces;

public interface IAuthService
{
    Task<bool> RegisterAsync(RegisterRequest request);

    Task<string?> LoginAsync(LoginRequest request);
}