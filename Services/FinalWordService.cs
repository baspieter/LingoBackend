using Lingo.Data;
using Lingo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lingo.Services
{
    public class FinalWordService : IFinalWordService
    { 
      private readonly IFinalWordRepo _finalWordRepo;

      public FinalWordService(IFinalWordRepo finalWordRepo)
      {
          _finalWordRepo = finalWordRepo;
      }

        public FinalWord SetFinalWord()
        {
          var x = _finalWordRepo.GetAllFinalWords().OrderBy(c => Guid.NewGuid());

          return x.First();
        }

        public string finalWordProgress(string finalWord, string guess)
        {
            var guessedWordChars = new List<char>(guess);
            if (guess == finalWord)
            {
                return new string(guessedWordChars.ToArray());
            }
        
            var finalWordChars = new List<char>(finalWord);
            var newFinalWordProgress = new List<char>();
            for(var i = 0; i < finalWordChars.Count; i++)
            {
                if (guessedWordChars.Count != finalWordChars.Count || finalWordChars[i] != guessedWordChars[i])
                {
                    newFinalWordProgress.Add('.');
                }
            }
            return new string(newFinalWordProgress.ToArray());
        }

        public string addFinalWordHint(string finalWord, string finalWordProgress)
        {
            List<char> finalWordChars = new List<char>(finalWord);
            List<char> progressChars = new List<char>(finalWordProgress);
            List<int> emptyChars = new List<int>();

            // Get all positions of chars that have not been guessed yet.
            for (var i = 0; i < progressChars.Count; i++)
            {
                if (progressChars[i] == '.')
                {
                    emptyChars.Add(i);
                }
            }
            
            // Select one random index of the given list & add it to finalWordProgress
            var rnd = new Random();
            var selectedIndex = emptyChars[rnd.Next(0, emptyChars.Count - 1)];
            progressChars[selectedIndex] = finalWordChars[selectedIndex];
            
            return new string(progressChars.ToArray()); 
        }
    }
}