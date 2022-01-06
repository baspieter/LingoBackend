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
            var originalWord = gameWord.Word?.Name ?? throw new ArgumentNullException("gameWord.Word?.Name");
            if (originalWord == word) gameWord.Finished = true;
            gameWord.WordProgress.Add(word);
            var letterProgress = this.letterProgress(originalWord, word);
            
            gameWord.WordLetterProgress.Add(Convert.ToInt32(letterProgress));
            
            _gameWordRepo.SaveChanges();
            return gameWord;
        }

        private string letterProgress(string original, string submitted, string progress = "")
        {
            if (progress.Length == submitted.Length) return progress;
            var index = progress.Length;
            if (submitted[index] == original[index]) return letterProgress(original, submitted, ("1" + progress));
            if (original.Contains(submitted[index])) return letterProgress(original, submitted, ("2" + progress));

            return letterProgress(original, submitted, ("0" + progress));
        }
    }
}