using Lingo.Models;
using Microsoft.EntityFrameworkCore;

namespace Lingo.Data
{
  public class WordContext : DbContext
  {
    public WordContext(DbContextOptions<WordContext> opt) : base(opt)
    {
      
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
    }
    public DbSet<Word> Word { get; set; }
    public DbSet<Game> Game { get; set; }
  }
}