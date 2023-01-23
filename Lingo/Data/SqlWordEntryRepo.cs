using Lingo.Models;
using Microsoft.EntityFrameworkCore;

namespace Lingo.Data;

public class SqlWordEntryRepo : IWordEntryRepo
{
    private readonly LingoContext _context;
    
    public SqlWordEntryRepo(LingoContext context)
    {
        _context = context;
    }
    
    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }

    public void CreateWordEntry(WordEntry wordEntry)
    {
        if(wordEntry == null) {
            throw new ArgumentNullException(nameof(wordEntry));
        }

        _context.WordEntry.Add(wordEntry);
    }
}