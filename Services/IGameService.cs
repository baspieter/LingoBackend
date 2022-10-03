using Lingo.Dtos;
using Lingo.Models;

namespace Lingo.Services
{
    public interface IGameService
    {
        Game StartNewGame();
        Word? NewGameWord(int gameId);
        Dictionary<string, object> CheckFinalWord(int gameId, string finalWord);
        Dictionary<string, object> CheckGameWord(int gameId, string word);
        Dictionary<string, object> GetGameData(int gameId);
    }
}