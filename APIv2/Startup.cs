using APIv2.Data;
using Microsoft.EntityFrameworkCore;
using APIv2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication;
using System.Text;
using Azure.Identity;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.DataProtection;
using Azure.Security.KeyVault.Secrets;
using System.Security.Cryptography;

// Basic Builder
var builder = WebApplication.CreateBuilder(args);

// Azure KeyVault
var keyVaultEndpoint = builder.Configuration["KeyVaultConfig:KVUrl"];
var configBuilder = new ConfigurationBuilder();
configBuilder.AddConfiguration(builder.Configuration); // Mantén las configuraciones existentes
var client = new SecretClient(new Uri(keyVaultEndpoint), new DefaultAzureCredential());
configBuilder.AddAzureKeyVault(client, new AzureKeyVaultConfigurationOptions());
var config = configBuilder.Build();



// Add services to the container.
string AllowAnyOriginCors = "AllowAnyOriginCors";
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowAnyOriginCors,
        policy =>
        {
            policy.AllowAnyOrigin();
            policy.AllowAnyHeader();
        });
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // Configura la validación del token JWT
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = "GestionPersonalAPI",
        ValidIssuer = "api_python",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(client.GetSecret("JWTConfig--IssuerSigningKey").Value.Value)),
        TokenDecryptionKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(client.GetSecret("JWTConfig--TokenDecryptionKey").Value.Value))
    };
});

ConfigureService.RegisterRepositories(builder.Services);
ConfigureService.RegisterServices(builder.Services);
ConfigureService.RegisterMappers(builder.Services);
ConfigureService.RegisterValidators(builder.Services);

builder.Services.AddDbContextPool<PersonalDB>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseCors(AllowAnyOriginCors);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
