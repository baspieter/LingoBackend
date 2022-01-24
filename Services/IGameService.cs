using Lingo.Models;

namespace Lingo.Services
{
    public interface IGameService
    {
        Game StartNewGame();
        GameWord CheckWord(int gameId, string word);
        Word? NewGameWord(int gameId);

        bool CheckFinalWord(int gameId, string finalWord);
    }
}