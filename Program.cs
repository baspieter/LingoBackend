using Lingo.Data;
using Lingo.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<LingoContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("LingoConnection")).UseSnakeCaseNamingConvention());

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IWordRepo, SqlWordRepo>();

builder.Services.AddScoped<IGameRepo, SqlGameRepo>();

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

    context.Word.Add(new Word() { Name = "Bussen" });
    context.Game.Add(new Game() { FinalWordProgress = new List<char> {'d','d'}, FinalWord = new FinalWord() { Name = "EenLangWoord" } });
    context.SaveChanges();

    var word = context.Word.First();
    var game = context.Game.First();
    var finalWord = context.FinalWord.First();

    word.GameWords.Add(new GameWord()
    {
        Word = word,
        Game = game
    });

    context.SaveChanges();
}

app.Run();
