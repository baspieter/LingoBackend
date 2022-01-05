using Lingo.Data;
using Lingo.Models;

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
  }
}