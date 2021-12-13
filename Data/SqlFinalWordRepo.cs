using Lingo.Models;

namespace Lingo.Data
{
  public class SqlFinalWordRepo : IFinalWordRepo
  {
    private readonly LingoContext _context;

    public SqlFinalWordRepo(LingoContext context)
    {
        _context = context;
    }

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

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }
  }
}
