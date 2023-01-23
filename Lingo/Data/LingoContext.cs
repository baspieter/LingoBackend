using Lingo.Models;
using Microsoft.EntityFrameworkCore;

namespace Lingo.Data
{
  public class LingoContext : DbContext
  {
    #pragma warning disable 8618, anyothernumber
    public LingoContext(DbContextOptions<LingoContext> opt) : base(opt)
    {
    }
    #pragma warning restore 8618, anythingelse

    public DbSet<Word> Word { get; set; }
    public DbSet<Game> Game { get; set; }
    public DbSet<GameWord> GameWord { get; set; }
    public DbSet<FinalWord> FinalWord { get; set; }
    public DbSet<WordEntry> WordEntry { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FinalWord>()
            .HasMany(c => c.Games)
            .WithOne(e => e.FinalWord);

        modelBuilder.Entity<Game>()
            .HasMany(c => c.GameWords)
            .WithOne(e => e.Game);

        modelBuilder.Entity<Game>()
            .HasOne(c => c.FinalWord)
            .WithMany(e => e.Games);
        
        modelBuilder.Entity<Word>()
            .HasMany(c => c.GameWords)
            .WithOne(e => e.Word);

        modelBuilder.Entity<GameWord>()
            .HasOne(c => c.Game)
            .WithMany(e => e.GameWords);
        
        modelBuilder.Entity<GameWord>()
            .HasOne(c => c.Word)
            .WithMany(e => e.GameWords);

		modelBuilder.Entity<WordEntry>()
            .HasOne(c => c.GameWord)
            .WithMany(e => e.WordEntries);
    }
  }
}