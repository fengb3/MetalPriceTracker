using FastEndpoints.Swagger;
using Lib;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Add services to the container.
builder.Services.AddAuthorization();

builder.Services
       .AddFastEndpoints()
       .SwaggerDocument()
    ;

builder.AddMetalDb();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapDefaultEndpoints();

app.UseFastEndpoints()
   .UseSwaggerGen()
    ;

app.MapGet("/gg", ([Microsoft.AspNetCore.Mvc.FromBody] Somebody body) =>
{
    if(body.Age < 18) return Results.BadRequest("You are too young.");
    return Results.Ok($"Hello, {body.Name}!");
});

app.Run();

public class Somebody
{
    public string Name { get; set; }
    public int Age { get; set; }
}