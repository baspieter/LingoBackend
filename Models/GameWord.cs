using System.ComponentModel.DataAnnotations;
using Lingo.Models;

namespace Lingo.Models
{
    public enum LetterColor
    {
        Empty, Green, Red, Orange
    }
  public class GameWord
  {
      [Key]
      public int Id { get; set; }
      
      [Required]
      public int WordId { get; set; }
      public Word? Word { get; set; }
      [Required]
      public int GameId { get; set; }
      
      public Game? Game { get; set; }

      [Required]
      public List<string> WordProgress { get; set; } = new();
      
      [Required]
      public List<LetterColor> LetterProgress { get; init; } = new()
      { 
          LetterColor.Empty, LetterColor.Empty, LetterColor.Empty, LetterColor.Empty, LetterColor.Empty, LetterColor.Empty
      };
      
      public bool Finished { get; set; } = false;
  }
}