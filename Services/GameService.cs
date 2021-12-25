using Lingo.Data;
using Lingo.Models;
using Microsoft.EntityFrameworkCore;

namespace Lingo.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepo _gameRepo;
        private readonly IFinalWordService _finalWordService;
        private readonly IWordService _wordService;

        public GameService(IGameRepo gameRepo, IFinalWordService finalWordService, IWordService wordService)
        {
            _gameRepo = gameRepo;
            _finalWordService = finalWordService;
            _wordService = wordService;
        }

        public Game StartNewGame()
        {
            var word = _wordService.SetWord();
            var finalWord = _finalWordService.SetFinalWord();
            if (word == null || finalWord?.Name == null)
            {
                throw new ArgumentNullException();
            }

            var finalWordProgress = SetFinalWordProgress(finalWord);
            var game = new Game
            {
                FinalWordProgress = finalWordProgress,
                FinalWord = finalWord,
                GameWords = new List<GameWord> { new GameWord { Word = word }}
            };

            _gameRepo.Add(game);
            _gameRepo.SaveChanges();
            return game;
        }

        private static List<char> SetFinalWordProgress(FinalWord finalWord)
        {
            var list = new List<char> { };
            for (var i = 0; i < finalWord.Name!.Length; i++)
            {
                list.Insert(i, ' ');
            }

            return list;
        }
    }
}