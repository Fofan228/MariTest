using Mari.Client.Common.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;

namespace Mari.Client.Common.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddClientServices(this IServiceCollection services)
    {
        services.AddScoped<AuthenticationStateProvider, MariAuthStateProvider>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}
