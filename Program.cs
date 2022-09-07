using BlazorApplicationInsights;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Portfolio;
using Portfolio.Interfaces;
using Portfolio.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
// builder.Services.AddHttpClient("Data", client => 
//     client.BaseAddress = new Uri("https://bradystroud.github.io"));
builder.Services.AddScoped<IContentService, ContentService>();
builder.Services.AddScoped<IProjectsService, ProjectsService>();
builder.Services.AddBlazorApplicationInsights();


await builder.Build().RunAsync();
