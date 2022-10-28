using Mari.Application.Common.Interfaces.Authentication;
using Mari.Application.Common.Interfaces.CommonServices;
using Mari.Infrastructure.Authentication.Services;
using Mari.Infrastructure.Authentication.Settings;
using Mari.Infrastructure.CommonServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mari.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}
