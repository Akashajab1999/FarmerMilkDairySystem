using SmartDairy.Application.Common.Models;
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

    public async Task<ApiResponse<object>> RegisterAsync(RegisterRequest request)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);

        if (existingUser != null)
            return ApiResponse<object>.FailureResponse("User already exists.");

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

        return ApiResponse<object>.SuccessResponse(
            null,
            "User registered successfully.");
    }
    public async Task<ApiResponse<LoginResponse>> LoginAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user == null)
        {
            return ApiResponse<LoginResponse>.FailureResponse("Invalid email or password.");
        }

        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

        if (!isPasswordValid)
        {
            return ApiResponse<LoginResponse>.FailureResponse("Invalid email or password.");
        }

        var token = _jwtService.GenerateToken(user.Email, user.Role);

        var response = new LoginResponse
        {
            Token = token,
            Email = user.Email,
            Role = user.Role
        };

        return ApiResponse<LoginResponse>.SuccessResponse(
            response,
            "Login successful.");
    }
}