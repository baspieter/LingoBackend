using Lingo.Data;
using Lingo.Models;
using Lingo.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<LingoContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("LingoConnection")).UseSnakeCaseNamingConvention());

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IWordRepo, SqlWordRepo>();

builder.Services.AddScoped<IGameRepo, SqlGameRepo>();

builder.Services.AddScoped<IFinalWordRepo, SqlFinalWordRepo>();

builder.Services.AddScoped<IGameWordRepo, SqlGameWordRepo>();

builder.Services.AddScoped<IFinalWordService, FinalWordService>();

builder.Services.AddScoped<IGameService, GameService>();

builder.Services.AddScoped<IWordService, WordService>();

builder.Services.AddScoped<IGameWordService, GameWordService>();

builder.Services.AddTransient<DataSeeder>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<LingoContext>();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
    
    var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    dataSeeder.Seed();
}

app.Run();
