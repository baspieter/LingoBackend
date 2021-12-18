using Lingo.Models;
using Microsoft.EntityFrameworkCore;

namespace Lingo.Data
{
  public class SqlFinalWordRepo : IFinalWordRepo
  {
    private readonly LingoContext _context;

    public SqlFinalWordRepo(LingoContext context)
    {
        _context = context;
    }

    public IEnumerable<FinalWord> GetAllFinalWords()
    {
      return _context.FinalWord.ToList();
    }

    public void CreateFinalWord(FinalWord finalWord)
    {
      if(finalWord == null) {
        throw new ArgumentNullException(nameof(finalWord));
      }

      _context.FinalWord.Add(finalWord);
    }

    public void DeleteFinalWord(FinalWord finalWord)
    {
      if(finalWord == null)
      {
        throw new ArgumentNullException(nameof(finalWord));
      }

      _context.FinalWord.Remove(finalWord);
    }

    public void UpdateFinalWord(FinalWord finalWord) {}

    public FinalWord GetFinalWordById(int id)
    {
      var finalWord = _context.FinalWord.FirstOrDefault(p => p.Id == id);
      if(finalWord != null)
      {
        return finalWord;
      } else {
        throw new ArgumentNullException(nameof(finalWord));
      }
    }

    public async Task<FinalWord> GetFirstRecordAsync()
    {
      return ( await _context.FinalWord.SingleAsync(x => x.Id == 1));
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }
  }
}
