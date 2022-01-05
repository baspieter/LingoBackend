using Lingo.Models;

namespace Lingo.Data
{
  public interface IGameWordRepo
  {
    bool SaveChanges();
    void CreateGameWord(GameWord gameWord);
    GameWord GetGameWordById(int id);
  }
}