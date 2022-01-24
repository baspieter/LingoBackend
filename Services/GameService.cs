using Lingo.Data;
using Lingo.Models;
using Microsoft.EntityFrameworkCore;

namespace Lingo.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepo _gameRepo;
        private readonly IGameWordRepo _gameWordRepo;
        private readonly IFinalWordService _finalWordService;
        private readonly IWordService _wordService;
        private readonly IGameWordService _gameWordService;

        public GameService(IGameRepo gameRepo, IGameWordRepo gameWordRepo, IFinalWordService finalWordService, IWordService wordService, IGameWordService gameWordService)
        {
            _gameRepo = gameRepo;
            _gameWordRepo = gameWordRepo;
            _finalWordService = finalWordService;
            _wordService = wordService;
            _gameWordService = gameWordService;
        }

        public Game StartNewGame()
        {
            var word = _wordService.SetWord();
            var finalWord = _finalWordService.SetFinalWord();
            if (word == null || finalWord == null)
            {
                throw new ArgumentNullException();
            }

            var game = new Game
            {
                FinalWord = finalWord
            };

            var gameWord = new GameWord
            {
                Game = game,
                Word = word
            };

            _gameRepo.Add(game);
            _gameRepo.SaveChanges();
            _gameWordRepo.CreateGameWord(gameWord);
            _gameWordRepo.SaveChanges();
            
            
            return game;
        }

        public GameWord CheckWord(int gameId, string word)
        {
            var game = FindGame(gameId);
            var gameWord = FindGameWord(game);
            var gameWordresult = _gameWordService.UpdateGameWord(gameWord, word);
            return gameWordresult;
        }

        public bool CheckFinalWord(int gameId, string finalWord)
        {
            var game = FindGame(gameId);
            var originalFinalWord = game.FinalWord.Name;
            if (originalFinalWord == null) throw new ArgumentNullException();
            
            var result = originalFinalWord.Equals(finalWord);
            
            if (result) FinishGame(game);
            return result;
        }

        public Word? NewGameWord(int gameId)
        {
            var gameWords = FindGame(gameId)?.GameWords;
            var usedWordIds = gameWords?.Select(gameWord => gameWord.Word.Id).ToArray();
            return usedWordIds == null ? throw new ArgumentNullException() : _wordService.SetGameWord(usedWordIds);
        }

        private Game FindGame(int gameId)
        {
            return _gameRepo.GetGameById(gameId);
        }

        private GameWord FindGameWord(Game game)
        {
            var gameWords = _gameWordRepo.GetGameWordsByGame(game);
            var currentGameWord = gameWords.Include(a => a.Word).OrderBy(p => p.Finished == true).Last();
            return currentGameWord;
        }

        private void FinishGame(Game game)
        {
            game.Status = Status.Finished;
            _gameRepo.SaveChanges();
        }
    }
}
