using PokemonApi.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using PokemonApi.Services;
using PokemonApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDBSettings"));

builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
{
    var settings = serviceProvider.GetRequiredService<IOptions<MongoDBSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});


// Register the PokemonService
//Addscoped cause it enables the connection with the database instead of addsinglon, which enables only instanting one time and dosn't support db
builder.Services.AddScoped<IPokemonService, PokemonService>();

builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
