using SocialMediaProfile.Services;
using SocialMediaProfile.Services.Interfaces;
using SocialMediaProfile.DataAccess;
using SocialMediaProfile.Repositories.Interfaces;
using SocialMediaProfile.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AutoMapper;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddAutoMapper(typeof(GenericService<,,>));

// Add services to the container.
builder.Services.AddDbContext<SocialMediaDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")); // SocialMediaProfile.DataAccess
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // SocialMediaProfile.Repositories

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped(typeof(IGenericService<,,>), typeof(GenericService<,,>));

builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPersonService, PersonService>(); 
builder.Services.AddScoped<IExperienceService, ExperienceService>(); // SocialMediaProfile.Core
builder.Services.AddScoped<IEducationService, EducationService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Adding Authorize for Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "SocialMediaAPI", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

// Adding JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]))
    };
    #region EventsCookies
    //options.Events = new JwtBearerEvents
    //{
    //    OnMessageReceived = context =>
    //    {
    //        if (context.Request.Cookies.ContainsKey("token"))
    //        {
    //            context.Token = context.Request.Cookies["token"];
    //        }
    //        return Task.CompletedTask;
    //    }
    //};
    #endregion
});

// Adding JWT Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
    options.AddPolicy("RegularPolicy", policy => policy.RequireRole("Regular"));
});

const string policy = "defaultPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(policy,
        builder =>
        {
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
            builder.AllowAnyOrigin();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
