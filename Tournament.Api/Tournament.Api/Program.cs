﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tournament.Api.Extensions;
using Tournament.Core.Repositories;
using Tournament.Core.Services;
using Tournament.Data;
using Tournament.Data.Data;
using Tournament.Data.Repositories;
using Tournament.Data.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson();

builder.Services.AddDbContext<TournamentApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TournamentApiContext") ?? throw new InvalidOperationException("Connection string 'TournamentApiContext' not found.")));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(TournamentMappings));
builder.Services.AddAutoMapper(typeof(GameMapping));


// Register the Unit of Work service with a scoped lifetime.
builder.Services.AddScoped<IUoW, UoW>();

// Register the GameRepository service with a scoped lifetime.
builder.Services.AddScoped<IGameRepository, GameRepository>();

// Register the TourRepository service with a scoped lifetime.
builder.Services.AddScoped<ITourRepository, TourRepository>();

// Register the TourService service with a scoped lifetime.
builder.Services.AddScoped<ITourService, TourService>();

// Register a Lazy<ITourRepository> using a factory function to resolve dependencies.
builder.Services.AddScoped(provider => new Lazy<ITourRepository>(() => provider.GetRequiredService<ITourRepository>()));

// Register a Lazy<ITourService> using a factory function to resolve dependencies.
builder.Services.AddScoped(provider => new Lazy<ITourService>(() => provider.GetRequiredService<ITourService>()));

// Register the ServiceManager service with a scoped lifetime.
builder.Services.AddScoped<IServiceManager, ServiceManager>();



var app = builder.Build();



    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        await app.SeedDataAsync();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

