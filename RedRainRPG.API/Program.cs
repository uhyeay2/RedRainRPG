global using FastEndpoints;
using FastEndpoints.Swagger;
using RedRain.DataAccess.Repositories;
using RedRainRPG.API.Config;
using RedRainRPG.Domain.Interfaces;
using RedRainRPG.Domain.Interfaces.Repositories;

var builder = WebApplication.CreateBuilder();

builder.Services.AddFastEndpoints();

builder.Services.AddScoped<IConfig, RedRainRPGConfig>();

builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

builder.Services.AddSwaggerDoc();

var app = builder.Build();

app.UseFastEndpoints();

app.UseOpenApi();

app.UseSwaggerUi3(s => s.ConfigureDefaults());

app.Run();