using Lingo.Data;
using Lingo.Models;
using System.Threading;
using System.Threading.Tasks;

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
  }
}