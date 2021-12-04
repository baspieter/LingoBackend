using Lingo.Models;
using Microsoft.EntityFrameworkCore;

namespace Lingo.Data
{
  public class WordContext : DbContext
  {
    public WordContext(DbContextOptions<WordContext> opt) : base(opt)
    {

    }
    public DbSet<Word> Word { get; set; }
  }
}