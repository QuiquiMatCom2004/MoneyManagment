using Application.Handlers.Test;
using FastEndpoints;
using FastEndpoints.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthenticationJwtBearer(s => s.SigningKey = "The secret used to sign tokens"); 
builder.Services.AddAuthorization();
builder.Services.AddFastEndpoints();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<TestCommandHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication()
    .UseAuthorization();

app.UseFastEndpoints();

app.Run();
