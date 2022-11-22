using Mari.Client.Common.Http.DelegatingHandlers;
using Mari.Http.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Mari.Client.Common.Http;

public static class DependencyInjection
{
    public static IServiceCollection AddHttpUtils(this IServiceCollection services, IWebAssemblyHostEnvironment environment)
    {
        services.AddScoped<HttpSender>(sp => new HttpSender(sp.GetService<IHttpClientFactory>()!)
        {
            HttpClientName = HttpClientNames.Api
        });

        services.AddScoped<ProblemHandler>();

        services.AddTransient<ApiAuthorizationHeaderHandler>();

        services.AddHttpClient(HttpClientNames.Api, client =>
        {
            client.BaseAddress = new Uri(environment.BaseAddress);
        })
        .AddHttpMessageHandler<ApiAuthorizationHeaderHandler>();

        services.AddScoped(sp =>
            sp.GetService<IHttpClientFactory>()!
            .CreateClient(HttpClientNames.Api));
        return services;
    }
}
