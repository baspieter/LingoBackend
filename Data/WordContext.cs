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
      modelBuilder.Entity<GameWord>() 
          .HasKey(x => new {x.GameId, x.WordId});
    }
    public DbSet<Word> Word { get; set; }
    public DbSet<Game> Game { get; set; }
    
    public DbSet<GameWord> GameWord { get; set; }
  }
}