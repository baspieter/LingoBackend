using Lingo.Data;
using Lingo.Models;
using Microsoft.EntityFrameworkCore;

namespace Lingo.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepo _gameRepo;
        private readonly IFinalWordService _finalWordService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWordService _wordService;

        public GameService(IGameRepo gameRepo, IFinalWordService finalWordService, IWordService wordService, IUnitOfWork unitOfWork)
        {
            _gameRepo = gameRepo;
            _finalWordService = finalWordService;
            _unitOfWork = unitOfWork;
            _wordService = wordService;
        }

        public async Task<Game> StartNewGame()
        {
            var word = await _wordService.SetWordAsync();
            var game = new Game
            {
                FinalWordProgress = new List<Char> { 'd', 's', 'a' },
                FinalWord = await _finalWordService.SetFinalWordAsync(),
                GameWords = new List<GameWord> { new GameWord { Word = word }}
            };

            await _gameRepo.AddAsync(game);
            await _unitOfWork.SaveChangesAsync();
            return game;
        }
    }
}