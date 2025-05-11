using Interview360.Application.Common.Interfaces;
using Interview360.Domain.Identity;
using Interview360.Infrastructure.Services;
using Interview360.Infrastructure.Settings;
using Interview360.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Interview360.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure Settings
        services.Configure<JwtSettings>(configuration.GetSection("JWT"));
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

        // Redis Configuration
        services.AddSingleton<IConnectionMultiplexer>(sp => 
            ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")!));
        services.AddScoped<IMemoryCacheService, RedisCacheService>();

        // Identity Configuration
        services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        // Services
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IEmailService, EmailService>();

        return services;
    }
} 