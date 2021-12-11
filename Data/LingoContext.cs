using Lingo.Models;
using Microsoft.EntityFrameworkCore;

namespace Lingo.Data
{
  public class LingoContext : DbContext
  {
    public LingoContext(DbContextOptions<LingoContext> opt) : base(opt)
    {
    }

    public DbSet<Word> Word { get; set; }
    public DbSet<Game> Game { get; set; }
    public DbSet<GameWord> GameWord { get; set; }
    public DbSet<FinalWord> FinalWord { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<GameWord>() 
          .HasKey(x => new {x.GameId, x.WordId});

      modelBuilder.Entity<FinalWord>()
        .HasMany(c => c.Games)
        .WithOne(e => e.FinalWord);
    }
  }
}