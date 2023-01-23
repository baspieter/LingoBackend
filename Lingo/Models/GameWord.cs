using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lingo.Models;

namespace Lingo.Models
{
    public class GameWord
  {
      public GameWord()
      {
      }

      public GameWord(Word? word)
      {
          Word = word;
      }

      [Key]
      public int Id { get; set; }
      
      [Required]
      public Word Word { get; set; }
      [Required]
      public Game Game { get; set; }
      public ICollection<WordEntry>? WordEntries { get; set; }
      public bool Finished { get; set; } = false;
  }
}