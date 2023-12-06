using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PunchodeStudios.Admin;
using PunchodeStudios.Admin.Contracts;
using PunchodeStudios.Admin.Services;
using PunchodeStudios.Admin.Services.Base;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7225"));

builder.Services.AddScoped<IGalleryService, GalleryService>();
builder.Services.AddScoped<IGalleryTypeService, GalleryTypeService>();
builder.Services.AddScoped<IGalleryCategoryService, GalleryCategoryService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

await builder.Build().RunAsync();
