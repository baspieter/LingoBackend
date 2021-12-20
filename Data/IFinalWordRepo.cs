using Lingo.Models;

namespace Lingo.Data
{
  public interface IFinalWordRepo
  {
    bool SaveChanges();
    FinalWord GetFinalWordById(int id);
    void CreateFinalWord(FinalWord finalWord);
    IEnumerable<FinalWord> GetAllFinalWords();
    FinalWord FindNewWord();
    void UpdateFinalWord(FinalWord finalWord);
    void DeleteFinalWord(FinalWord finalWord);
  }
}