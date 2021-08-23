using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RainOrShine.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddOidcAuthentication(options =>
{
	// Configure your authentication provider options here.
	// For more information, see https://aka.ms/blazor-standalone-auth
	builder.Configuration.Bind("Google", options.ProviderOptions);
	options.ProviderOptions.DefaultScopes.Add("email");
	options.ProviderOptions.DefaultScopes.Add("profile");
});

await builder.Build().RunAsync();
