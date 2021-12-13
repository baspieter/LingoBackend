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
      return _context.FinalWord.FirstOrDefault(p => p.Id == id);
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }
  }
}
