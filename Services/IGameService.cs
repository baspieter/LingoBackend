using Lingo.Dtos;
using Lingo.Models;

namespace Lingo.Services
{
    public interface IGameService
    {
        Game StartNewGame();
        Word? NewGameWord(int gameId);
        Dictionary<string, object> CheckFinalWord(int gameId, string finalWord, int timer);
        Dictionary<string, object> CheckGameWord(int gameWordId, string word, int timer);
        Dictionary<string, object> GetGameData(int gameId, int gameWordId=0);
        Dictionary<string, object> NextRound(int gameId, int timer);
        Dictionary<string, object> UpdateTimer(int gameId, int timer);
    }
}