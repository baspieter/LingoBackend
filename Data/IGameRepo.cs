using Lingo.Models;

namespace Lingo.Data
{
  public interface IGameRepo
  {
    bool SaveChanges();

    IEnumerable<Game> GetAllGames();

    Game GetGameById(int id);

    void UpdateGame(Game game);

    Game Add(Game game);
    void CreateGame(Game game);
  }
}