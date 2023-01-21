using Lingo.Models;
using Microsoft.EntityFrameworkCore;

namespace Lingo.Data
{
  public class SqlGameRepo : IGameRepo
  {
    private readonly LingoContext _context;

    public SqlGameRepo(LingoContext context)
    {
        _context = context;
    }

    public IEnumerable<Game> GetAllGames()
    {
      return _context.Game.ToList();
    }

    public void CreateGame(Game game)
    {
      if(game == null) {
        throw new ArgumentNullException(nameof(game));
      }

      _context.Game.Add(game);
    }

    public Game GetGameById(int id)
    {
      var game = _context.Game.Where(game => game.Id == id).Include(a => a.FinalWord).FirstOrDefault();
      if(game != null)
      {
        return game;
      } else {
        throw new ArgumentNullException(nameof(game));
      }
    }

    public Game Add(Game game)
    {
      _context.Add(game);

      return game;
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }

    public void UpdateGame(Game game)
    {
      // Nothing
    }
  }
}
