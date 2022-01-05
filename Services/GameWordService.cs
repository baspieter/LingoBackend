using Lingo.Data;
using Lingo.Models;

namespace Lingo.Services
{
    public class GameWordService : IGameWordService
    { 
        private readonly IGameWordRepo _gameWordRepo;

        public GameWordService(IGameWordRepo gameWordRepo)
        {
            _gameWordRepo = gameWordRepo;
        }

        public GameWord UpdateGameWord(GameWord gameWord, string word)
        {
            var originalWord = gameWord.Word?.Name;



            if (originalWord == word)
            {
                gameWord.Finished = true;
            }

            _gameWordRepo.SaveChanges();
            return gameWord;
        }
    }
}