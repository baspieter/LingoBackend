using Lingo.Models;

namespace Lingo.Data
{
  public interface IGameRepo
  {
    bool SaveChanges();

    Game GetGameById(int id);
    void CreateGame(Game game);
  }
}