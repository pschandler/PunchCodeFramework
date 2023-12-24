using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PunchcodeStudios.Admin;
using PunchcodeStudios.Admin.Contracts;
using PunchcodeStudios.Admin.Providers;
using PunchcodeStudios.Admin.Services;
using PunchcodeStudios.Admin.Services.Base;
using Radzen;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7225"));
builder.Services.AddBlazoredToast();
builder.Services.AddRadzenComponents();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

builder.Services.AddScoped<IGalleryService, GalleryService>();
builder.Services.AddScoped<IGalleryTypeService, GalleryTypeService>();
builder.Services.AddScoped<IGalleryCategoryService, GalleryCategoryService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();



builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddBlazorBootstrap();

await builder.Build().RunAsync();
