using Lingo.Models;

namespace Lingo.Services
{
    public interface IGameService
    {
        Task<Game> StartNewGame();
    }
}