using Lingo.Models;
using Microsoft.EntityFrameworkCore;

namespace Lingo.Data
{
  public class SqlGameWordRepo : IGameWordRepo
  {
    private readonly LingoContext _context;

    public SqlGameWordRepo(LingoContext context)
    {
        _context = context;
    }

    public void CreateGameWord(GameWord gameWord)
    {
      if(gameWord == null) {
        throw new ArgumentNullException(nameof(gameWord));
      }

      _context.GameWord.Add(gameWord);
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }
    
    public GameWord GetGameWordById(int id)
    {
      var gameWord = _context.GameWord.FirstOrDefault(p => p.Id == id);
      if(gameWord != null)
      {
        return gameWord;
      } else {
        throw new ArgumentNullException(nameof(gameWord));
      }
    }

    public IQueryable<GameWord> GetGameWordsByGame(Game game)
    {
      return _context.GameWord.Where(p => p.Game == game).Include(a => a.Word);
    }
  }
}
