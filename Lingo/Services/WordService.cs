using Lingo.Data;
using Lingo.Models;

namespace Lingo.Services
{
    public class WordService : IWordService
    {
        private readonly IWordRepo _wordRepo;

        public WordService(IWordRepo wordRepo)
        {
            _wordRepo = wordRepo;
        }

        public Word SetWord()
        {
            var words = _wordRepo.GetAllWords().OrderBy(c => Guid.NewGuid());

            return words.First();
        }

        public Word SetGameWord(IEnumerable<int> usedWordIds)
        {
            return _wordRepo.GetAllWords().First(word => !usedWordIds.Contains(word.Id));
        }
    }
}
