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
        // Back-end code for updating word progress. Is now being done by frontend.
        //
        // public GameWord UpdateGameWord(GameWord gameWord, string word)
        // {
        //     var originalWord = gameWord.Word.Name;
        //     if (originalWord == null) throw new ArgumentNullException();
        //     gameWord.WordProgress.Add(word);
        //     // if (originalWord == word) gameWord.Finished = true;
        //     
        //     var originalWordChars = originalWord.ToList();
        //     var submittedWordChars = word.ToList();
        //     var letterProgress = this.letterProgress(originalWordChars, submittedWordChars);
        //
        //     gameWord.WordLetterProgress.Add(Convert.ToInt32(letterProgress));
        //     
        //     _gameWordRepo.SaveChanges();
        //     return gameWord;
        // }
        //
        //
        // // 1 = Fout (Rood), 2 = Goed (Groen), 3 = Andere positie (Geel)
        // private string letterProgress(List<char> original, List<char> submitted, String completedLetters = "", string progress = "")
        // {
        //     if (submitted.Count == 0) return progress;
        //     var current = submitted.First();
        //     submitted.Remove(current);
        //     
        //     if (current == original[progress.Length]) return letterProgress(original, submitted, (completedLetters + current), (progress + "2"));
        //     if (original.Contains(current) && !completedLetters.Contains(current)) return letterProgress(original, submitted, completedLetters, (progress + "3"));
        //     return letterProgress(original, submitted, completedLetters, (progress + "1"));
        //
        // }
    }
}