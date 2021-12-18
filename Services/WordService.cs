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

    public async Task<Word> SetWordAsync()
    {
      var word = (await _wordRepo.GetFirstRecordAsync());

      return word;
    }
  }
}