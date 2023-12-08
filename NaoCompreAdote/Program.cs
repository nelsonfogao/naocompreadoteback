using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Google.Api;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IAdotanteRepository, AdotanteRepository>();
builder.Services.AddTransient<IAdocoesRepository, AdocoesRepository>();
builder.Services.AddTransient<IDoadorRepository, DoadorRepository>();
builder.Services.AddTransient<IPetRepository, PetRepository>();
builder.Services.AddTransient<IAdotanteService, AdotanteService>();
builder.Services.AddTransient<IAdocoesService, AdocoesService>();
builder.Services.AddTransient<IDoadorService, DoadorService>();
builder.Services.AddTransient<IPetService, PetService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<WebApiContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("WebApiContext")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
