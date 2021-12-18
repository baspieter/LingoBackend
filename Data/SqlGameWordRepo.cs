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
  }
}
