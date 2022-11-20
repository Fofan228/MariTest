using Mari.Http.Services;

namespace Mari.Client.Common.Http;

public static class DependencyInjection
{
    public static IServiceCollection AddHttpUtils(this IServiceCollection services)
    {
        services.AddScoped<HttpSender>(sp => new HttpSender(sp.GetService<IHttpClientFactory>()!)
        {
            HttpClientName = HttpClientNames.Api
        });
        services.AddScoped<ProblemHandler>();
        return services;
    }
}
