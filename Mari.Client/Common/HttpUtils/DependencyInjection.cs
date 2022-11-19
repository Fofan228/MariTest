using Mari.Client.Common.Utils.HttpUtils;

namespace Mari.Client.Common.HttpUtils;

public static class DependencyInjection
{
    public static IServiceCollection AddHttpUtils(this IServiceCollection services)
    {
        services.AddScoped<HttpSender>();
        services.AddScoped<ProblemHandler>();
        return services;
    }
}
