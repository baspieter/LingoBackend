using Lingo.Models;

namespace Lingo.Data
{
  public interface IWordRepo
  {
    bool SaveChanges();
    IEnumerable<Word> GetAllWords();
    Word GetWordById(int id);
    void CreateWord(Word word);
    void UpdateWord(Word word);
    Word GetFirstRecord();
    void DeleteWord(Word word);
  }
}