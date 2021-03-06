using Lingo.Models;
using Microsoft.EntityFrameworkCore;

namespace Lingo.Data
{
  public class SqlWordRepo : IWordRepo
  {
    private const string V = "Not found";
    private readonly LingoContext _context;

    public SqlWordRepo(LingoContext context)
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

    public Word GetFirstRecord()
    {
      return ( _context.Word.Single(x => x.Id == 1));
    }

    public Word GetWordById(int id)
    {
      var word = _context.Word.FirstOrDefault(p => p.Id == id);
      if(word != null)
      {
        return word;
      } else {
        throw new ArgumentNullException(nameof(word));
      }
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }

    public void UpdateWord(Word word) {}
  }
}
