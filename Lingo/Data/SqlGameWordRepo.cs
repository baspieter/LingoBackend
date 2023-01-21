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

    public void AddSubmittedWord(GameWord gameWord, String submittedWord)
    {
      gameWord.WordProgress.Add(submittedWord);
    }

    public bool FinishedGameWord(GameWord gameWord)
    {
      var word = gameWord.Word.Name;
      return gameWord.WordProgress.Last() == word || gameWord.WordProgress.Count == 5;
    }

    public void FinishGameWord(GameWord gameWord)
    {
      gameWord.Finished = true;
    }
    
    public GameWord GetGameWordById(int id)
    {
      return _context.GameWord.Where(p => p.Id == id).Include(gameWord => gameWord.Word).Include( gameWord => gameWord.Game).FirstOrDefault();
    }

    public IQueryable<GameWord> GetGameWordsByGame(Game game)
    {
      return _context.GameWord.Where(p => p.Game == game).Include(a => a.Word);
    }
  }
}
