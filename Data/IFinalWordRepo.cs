using Lingo.Models;

namespace Lingo.Data
{
  public interface IFinalWordRepo
  {
    bool SaveChanges();

    FinalWord GetFinalWordById(int id);
    Task<FinalWord> GetFirstRecordAsync();
  }
}