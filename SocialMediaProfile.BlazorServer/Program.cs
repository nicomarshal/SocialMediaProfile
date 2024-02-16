using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using SocialMediaProfile.BlazorServer.AuthState;
using SocialMediaProfile.BlazorServer.Data;
using SocialMediaProfile.BlazorServer.Data.Interfaces;
using SocialMediaProfile.BlazorServer.Handlers;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<WeatherForecastService>(); //TODO Borrar

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddSingleton<IGlobalWebService, GlobalWebService>();
builder.Services.AddScoped<IAuthWebService, AuthWebService>();
builder.Services.AddSingleton<IRoleWebService, RoleWebService>();
builder.Services.AddSingleton<IUserWebService, UserWebService>();
builder.Services.AddSingleton<IPersonWebService, PersonWebService>();
builder.Services.AddSingleton<IExperienceWebService, ExperienceWebService>();
builder.Services.AddSingleton<IEducationWebService, EducationWebService>();
builder.Services.AddSingleton<IProjectWebService, ProjectWebService>();
builder.Services.AddSingleton<ISkillWebService, SkillWebService>();

builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>();

//builder.Services.AddSingleton<IWebServiceFactory, WebServiceFactory>(); //TODO Borrar


builder.Services.AddTransient<AuthWebHandler>();
builder.Services.AddHttpClient("WebApi")
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(configuration["ApiUrl"]))
                .AddHttpMessageHandler<AuthWebHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
