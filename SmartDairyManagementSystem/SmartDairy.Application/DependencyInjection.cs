using Microsoft.Extensions.DependencyInjection;
using SmartDairy.Application.Features.Authentication.Interfaces;
using SmartDairy.Application.Features.Authentication.Services;
using SmartDairy.Application.Features.Farmers.Interfaces;
using SmartDairy.Application.Features.Farmers.Services;

namespace SmartDairy.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IFarmerService, FarmerService>();

        return services;
    }
}