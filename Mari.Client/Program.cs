using Blazored.LocalStorage;
using Mari.Client;
using Mari.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
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

services.AddOptions();
services.AddAuthorizationCore();
services.AddMudServices();
services.AddBlazoredLocalStorage();

services.AddHttpClient("Server", client => client.BaseAddress = new Uri(environment.BaseAddress));

services.AddScoped(sp => sp.GetService<IHttpClientFactory>()!.CreateClient("Server"));
services.AddScoped<AuthenticationStateProvider, MariAuthStateProvider>();

await builder.Build().RunAsync();
