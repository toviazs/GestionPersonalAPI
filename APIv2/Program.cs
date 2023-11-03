using APIv2.Data;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using APIv2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureService.RegisterRepositories(builder.Services);
ConfigureService.RegisterServices(builder.Services);
ConfigureService.RegisterMappers(builder.Services);
ConfigureService.RegisterValidators(builder.Services);

// Cargar variables de entorno
Env.Load();

// Leer cadena de conexion
var connectionString = Environment.GetEnvironmentVariable("ConnectionString");

// Configurar cadena de conexion
builder.Services.AddDbContextPool<PersonalDB>(
                       options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
