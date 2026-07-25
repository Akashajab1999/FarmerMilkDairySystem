namespace SmartDairy.Application.Features.Authentication.Interfaces;

public interface IJwtService
{
    string GenerateToken(string email, string role);
}