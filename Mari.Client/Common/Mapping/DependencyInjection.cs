using System.Reflection;
using Mapster;
using MapsterMapper;
using Mari.Client.Common.Interfaces.Managers;
using Mari.Client.Common.Services.Managers;

namespace Mari.Client.Common.Mapping;

public static class DependencyInjection
{
    public static IServiceCollection AddMapping(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        services.AddScoped<IReleaseManager, ReleaseManager>();
        return services;
    }
}
