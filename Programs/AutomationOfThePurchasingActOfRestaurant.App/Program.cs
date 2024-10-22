using Company.AutomationOfThePurchasingActOfRestaurant.App;
using Company.AutomationOfThePurchasingActOfRestaurant.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.FluentValidation;
using BlazorDownloadFile;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IPurchasingActOfRestaurantClient>(opt =>
{
    var httpClientFactory = opt.GetRequiredService<IHttpClientFactory>();
    var httpClient = httpClientFactory.CreateClient();
    return new PurchasingActOfRestaurantClient("https://localhost:7120/", httpClient);
});
builder.Services.AddHttpClient();
builder.Services.AddBlazorDownloadFile();


await builder.Build().RunAsync();
