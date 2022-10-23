using Lingo.Models;

namespace Lingo.Services
{
    public interface IWordService
    {
        Word SetWord();
        Word SetGameWord(IEnumerable<int> usedWordIds);
    }
}