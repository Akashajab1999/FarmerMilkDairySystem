using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartDairy.Application.Features.Authentication.Interfaces;
using SmartDairy.Infrastructure.Authentication;
using SmartDairy.Infrastructure.Settings;

namespace SmartDairy.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Bind Jwt section from appsettings.json
        services.Configure<JwtSettings>(
            configuration.GetSection("Jwt"));

        // Register JWT service
        services.AddScoped<IJwtService, JwtService>();

        return services;
    }
}