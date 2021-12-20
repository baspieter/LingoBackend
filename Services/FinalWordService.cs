using Lingo.Data;
using Lingo.Models;
using System.Threading;
using System.Threading.Tasks;

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
      var x = _finalWordRepo.FindNewWord();

      return x;
    }
  }
}