using Lingo.Models;

namespace Lingo.Services
{
    public interface IWordService
    {
        Task<Word> SetWordAsync();
    }
}