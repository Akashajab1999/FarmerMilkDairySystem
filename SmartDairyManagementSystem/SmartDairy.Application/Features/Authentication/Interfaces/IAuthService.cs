using SmartDairy.Application.Common.Models;
using SmartDairy.Application.Features.Authentication.DTOs;

public interface IAuthService
{
    Task<ApiResponse<object>> RegisterAsync(RegisterRequest request);

    public Task<ApiResponse<LoginResponse>> LoginAsync(LoginRequest request)
    {
        throw new NotImplementedException();
    }

}