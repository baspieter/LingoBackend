using Lingo.Data;
using Lingo.Models;
using Microsoft.EntityFrameworkCore;

namespace Lingo.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepo _gameRepo;
        private readonly IFinalWordService _finalWordService;

        public GameService(IGameRepo gameRepo, IFinalWordService finalWordService)
        {
            _gameRepo = gameRepo;
            _finalWordService = finalWordService;
        }

        public async Task<Game> StartNewGame()
        {
            var game = new Game
            {
                FinalWordProgress = new List<Char> { 'd', 's', 'a' },
                FinalWord = await _finalWordService.SetFinalWordAsync(),
            };

            await _gameRepo.Add(game);
            await _unitOfWork.SaveChangesAsync();
            // return game;
        }
    }
}