﻿using Application;
using Application.Helper;
using Application.Middlewares;
using Domain;
using Infrastructure;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
    .AddJsonFile("./appsettings.json")
    .Build();

// Add services to the container.
builder.Services.AddControllers();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseNpgsql(
        configuration["ConnectionString"], 
        b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().ToString())));

builder.Services.AddDomain();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod();
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

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthorization();

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
