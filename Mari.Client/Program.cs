using Blazored.LocalStorage;
using Mari.Client;
using Mari.Client.Common.Constants;
using Mari.Client.Common.HttpUtils;
using Mari.Client.Common.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var services = builder.Services;
var config = builder.Configuration;
var environment = builder.HostEnvironment;
var rootComponents = builder.RootComponents;

rootComponents.Add<App>("#app");
rootComponents.Add<HeadOutlet>("head::after");

services.AddClientServices();
services.AddHttpUtils();

services.AddHttpClient();
services.AddAuthorizationCore();
services.AddMudServices();
services.AddBlazoredLocalStorage();

services.AddHttpClient(HttpClientNames.Api, client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
services.AddScoped(sp => sp.GetService<IHttpClientFactory>()!.CreateClient(HttpClientNames.Api));

await builder.Build().RunAsync();
