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
            var originalWord = gameWord.Word.Name;
            if (originalWord == word) gameWord.Finished = true;
            gameWord.WordProgress.Add(word);


            // var OriginalWordChars = originalWord.ToCharArray();
            var OriginalWordChars = originalWord.ToList();
            var SubmittedWordChars = word.ToList();
            var letterProgress = this.letterProgress(OriginalWordChars, SubmittedWordChars);

            gameWord.WordLetterProgress.Add(Convert.ToInt32(letterProgress));
            
            _gameWordRepo.SaveChanges();
            return gameWord;
        }
        
        
        // 1 = Fout (Rood), 2 = Goed (Groen), 3 = Andere positie (Geel)
        private string letterProgress(List<char> original, List<char> submitted, String completedLetters = "", string progress = "")
        {
            if (submitted.Count == 0) return progress;
            var current = submitted.First();
            submitted.Remove(current);
            
            if (current == original[progress.Length]) return letterProgress(original, submitted, (completedLetters + current), (progress + "2"));
            if (original.Contains(current) && !completedLetters.Contains(current)) return letterProgress(original, submitted, completedLetters, (progress + "3"));
            return letterProgress(original, submitted, completedLetters, (progress + "1"));

        }
    }
}