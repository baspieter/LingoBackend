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

        public Task<Game> StartNewGame()
        {
            var word = _wordService.SetWord();
            var finalWord = _finalWordService.SetFinalWord();
            if (word == null || finalWord?.Name == null)
            {
                throw new ArgumentNullException();
            }

            var finalWordProgress = setFinalWordProgress(finalWord);
            var game = new Game
            {
                FinalWordProgress = finalWordProgress,
                FinalWord = finalWord,
                GameWords = new List<GameWord> { new GameWord { Word = word }}
            };

            await _gameRepo.AddAsync(game);
            await _unitOfWork.SaveChangesAsync();
            return game;
        }

        private List<char> setFinalWordProgress(FinalWord finalWord)
        {
            var list = new List<char> { };
            for (int i = 0; i < finalWord.Name!.Length; i++)
            {
                list.Insert(i, ' ');
            }

            return list;
        }
    }
}