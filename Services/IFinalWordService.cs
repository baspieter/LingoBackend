using Lingo.Models;

namespace Lingo.Services
{
    public interface IFinalWordService
    {
        FinalWord SetFinalWord();
        String finalWordProgress(String finalWord, String guess);
        String addFinalWordHint(String finalWord, String finalWordProgress);
    }
}