using Lingo.Models;

namespace Lingo.Data
{
  public interface IGameRepo
  {
    bool SaveChanges();

    Game GetGameById(int id);

    void UpdateGame(Game game);
    void CreateGame(Game game);
  }
}