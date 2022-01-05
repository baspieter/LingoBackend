using Lingo.Models;

namespace Lingo.Services
{
    public interface IGameService
    {
        Game StartNewGame();
        Word? CurrentGameWord(int gameId);

        Word? NewGameWord(int gameId);
    }
}