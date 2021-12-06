using Lingo.Models;

namespace Lingo.Data
{
  public class SqlWordRepo : IWordRepo
  {
    private readonly WordContext _context;

    public SqlWordRepo(WordContext context)
    {
        _context = context;
    }

    public void CreateWord(Word word)
    {
      if(word == null) {
        throw new ArgumentNullException(nameof(word));
      }

      _context.Word.Add(word);
    }

    public void DeleteWord(Word word)
    {
      if(word == null)
      {
        throw new ArgumentNullException(nameof(word));
      }

      _context.Word.Remove(word);
    }

    public IEnumerable<Word> GetAllWords()
    {
      return _context.Word.ToList();
    }

    public Word GetWordById(int id)
    {
      return _context.Word.FirstOrDefault(p => p.Id == id);
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }

    public void UpdateWord(Word word)
    {
      // Nothing
    }
  }
}
