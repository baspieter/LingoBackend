using Lingo.Models;

namespace Lingo.Data;

public interface IWordEntryRepo
{
    bool SaveChanges();
    void CreateWordEntry(WordEntry wordEntry);
}