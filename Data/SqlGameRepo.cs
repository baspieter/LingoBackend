using Lingo.Models;

namespace Lingo.Data
{
  public class SqlGameRepo : IGameRepo
  {
    private readonly LingoContext _context;

    public SqlGameRepo(LingoContext context)
    {
        _context = context;
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
      return _context.Game.FirstOrDefault(p => p.Id == id);
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }
  }
}
