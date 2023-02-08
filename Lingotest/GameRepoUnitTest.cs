using Lingo.Data;
using Lingo.Models;
using Microsoft.EntityFrameworkCore;

namespace Lingotest;

[TestClass]
public class UnitTest1
{
    private readonly LingoContext _context;
    public UnitTest1()
    {
        DbContextOptionsBuilder<LingoContext> dbOptions = new DbContextOptionsBuilder<LingoContext>()
            .UseInMemoryDatabase(
                Guid.NewGuid().ToString()
            );
            
        _context = new LingoContext(dbOptions.Options);
    }

    [TestMethod]
    public void GetGameById()
    {
        Random random = new Random();
        int gameId = random.Next();
        FinalWord finalWord = new FinalWord
        {
            Name = "Test word"
        };
        Game game = new Game
        {
            Id = gameId,
            FinalWord = finalWord
        };
        _context.FinalWord.Add(finalWord);
        _context.Game.Add(game);
        _context.SaveChanges();
        
        var repo = new SqlGameRepo(_context);
        
        var result = repo.GetGameById(gameId);

        Assert.AreEqual(result.Id, gameId);
    }
    
    [TestMethod]
    public void Add()
    {
        var repo = new SqlGameRepo(_context);
        Game game = new Game
        {
            Round = 8
        };
        
        Game result = repo.Add(game);
        _context.SaveChanges();
        
        List<Game> games = _context.Game.ToList();
        Assert.AreEqual(games.FirstOrDefault().Round, 8);
        Assert.AreEqual(games.Count, 1);
    }
    
    [TestMethod]
    public void GetAllGames()
    {
        var repo = new SqlGameRepo(_context);
        Game game1 = new Game();
        Game game2 = new Game();
        _context.Game.Add(game1);
        _context.Game.Add(game2);
        _context.SaveChanges();
        
        IEnumerable<Game> result = repo.GetAllGames();
        
        Assert.AreEqual(result.Count(), 2);
    }
}