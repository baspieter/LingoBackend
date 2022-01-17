using Lingo.Models;

namespace Lingo.Data
{
  public interface IGameWordRepo
  {
    bool SaveChanges();
    void CreateGameWord(GameWord gameWord);

    IQueryable<GameWord> GetGameWordsByGame(Game game);
    GameWord GetGameWordById(int id);
  }
}