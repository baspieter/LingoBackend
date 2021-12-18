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

    public async Task<FinalWord> SetFinalWordAsync()
    {
      var x = (await _finalWordRepo.GetFirstRecordAsync());

      return x;
    }
  }
}