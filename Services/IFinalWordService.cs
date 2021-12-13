using Lingo.Models;

namespace Lingo.Services
{
    public interface IFinalWordService
    {
        Task<FinalWord> SetFinalWordAsync();
    }
}