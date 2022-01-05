using Lingo.Data;
using Lingo.Models;

namespace Lingo.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepo _gameRepo;
        private readonly IFinalWordService _finalWordService;
        private readonly IWordService _wordService;
        private readonly IGameWordService _gameWordService;

        public GameService(IGameRepo gameRepo, IFinalWordService finalWordService, IWordService wordService, IGameWordService gameWordService)
        {
            _gameRepo = gameRepo;
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
                FinalWord = finalWord,
                GameWords = new List<GameWord> { new GameWord() { Word = word }}
            };

            _gameRepo.Add(game);
            _gameRepo.SaveChanges();
            return game;
        }

        public GameWord CheckWord(int gameId, string word)
        {
            var game = FindGame(gameId);
            var gameWord = FindGameWord(game);
            var gameWordresult = _gameWordService.UpdateGameWord(gameWord, word);
            return gameWordresult;
        }

        public Word? NewGameWord(int gameId)
        {
            var gameWords = FindGame(gameId)?.GameWords;
            var usedWordIds = gameWords?.Select(gameWord => gameWord.WordId).ToArray();
            return usedWordIds == null ? throw new ArgumentNullException() : _wordService.SetGameWord(usedWordIds);
        }

        // private static List<char> SetFinalWordProgress(FinalWord finalWord)
        // {
        //     var list = new List<char> { };
        //     for (var i = 0; i < finalWord.Name!.Length; i++)
        //     {
        //         list.Insert(i, ' ');
        //     }
        //
        //     return list;
        // }

        private Game FindGame(int gameId)
        {
            return _gameRepo.GetGameById(gameId);
        }

        private static GameWord FindGameWord(Game game)
        {
            if (game.GameWords == null)
            {
                throw new ArgumentNullException();
            }
            
            return game.GameWords.Last(gameWord => gameWord.Finished == false);
        }
    }
}
