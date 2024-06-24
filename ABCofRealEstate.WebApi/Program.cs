using System.Text;
using ABCofRealEstate.Data.Models.Entities;
using ABCofRealEstate.Services;
using ABCofRealEstate.Services.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ABCofRealEstate.WebApi;


public class AuthOptions
{
    public const string ISSUER = "MyAuthServer"; // издатель токена
    public const string AUDIENCE = "MyAuthClient"; // потребитель токена
    const string KEY = "mysupersecret_secretsecretsecretkey!123";   // ключ для шифрации
    public static SymmetricSecurityKey GetSymmetricSecurityKey() => 
        new (Encoding.UTF8.GetBytes(KEY));
}
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(policy => policy.AddPolicy("default", opt =>
        {
            opt.AllowAnyHeader();
            opt.AllowCredentials();
            opt.AllowAnyMethod();
            opt.SetIsOriginAllowed(_ => true);
        }));
        builder.Services.AddControllers();
        builder.Services.AddScoped<IApartmentService, ApartmentService>();
        builder.Services.AddScoped<IAreaService, AreaService>();
        builder.Services.AddScoped<IComertionService, ComertionService>();
        builder.Services.AddScoped<IGarageService, GarageService>();
        builder.Services.AddScoped<IHouseService, HouseService>();
        builder.Services.AddScoped<IHostelService, HostelService>();
        builder.Services.AddScoped<IRoomService, RoomService>();
        builder.Services.AddScoped<ISourceRealEstateObjectService, SourceRealEstateObjectService>();
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();
        builder.Services.AddScoped<IModeratorService, ModeratorService>();
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = AuthOptions.ISSUER,
                    ValidateAudience = true,
                    ValidAudience = AuthOptions.AUDIENCE,
                    ValidateLifetime = true,
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true
                };

            });
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy(nameof(Moderator.IsSuperModerator), policy =>
            {
                policy.RequireClaim(nameof(Moderator.Id));
                policy.RequireClaim(nameof(Moderator.IsSuperModerator), "True");
            });
            options.AddPolicy(nameof(Moderator), policy =>
            {
                policy.RequireClaim(nameof(Moderator.Id));
            });
        });
        builder.Services.AddSwaggerGen(option =>
        {
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                In = ParameterLocation.Header,
                Description = "Введите существующий токен",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme()
                    {
                        Reference = new OpenApiReference()
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new List<string>()
                }
            });
        });

        var app = builder.Build();
        
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseCors("default");
        app.UseStaticFiles();
        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}