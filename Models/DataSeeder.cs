using Lingo.Data;
using Lingo.Models;
using Lingo.Services;

namespace Lingo.Models
{
    public class DataSeeder
    {
        private readonly LingoContext _context;
        private readonly IGameService _gameService;
    
        public DataSeeder(LingoContext context, IGameService gameService)
        {
            _context = context;
            _gameService = gameService;
        }
    
        public void Seed()
        {
            CreateWords();
            CreateFinalWords();
            _context.SaveChanges();
            CreateGame();
            _context.SaveChanges();

            var game = _context.Game.First();
            var gamewords = game.GameWords;
        }

        private void CreateWords()
        {
            var words = new List<Word>()
            {
                new()
                {
                    Name = "bussen"
                },
                new()
                {
                    Name = "tassen"
                },
                new()
                {
                    Name = "rokjes"
                }
            };
            
            _context.Word.AddRange(words);
        }

        private void CreateFinalWords()
        {
            var finalWords = new List<FinalWord>()
            {
                new()
                {
                    Name = "Kerstmisfeest"
                },
                new()
                {
                    Name = "Proteineshaker"
                }
            };
            
            _context.FinalWord.AddRange(finalWords);
        }

        private void CreateGame()
        {
            var game = new Game()
            {
                FinalWord = _context.FinalWord.First()
            };

            var gameWord = new GameWord()
            {
                Game = game,
                Word = _context.Word.First()
            };
            
            _context.Game.AddRange(game);
            _context.GameWord.Add(gameWord);
        }
    }
}
