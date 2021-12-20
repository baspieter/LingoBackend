using System.ComponentModel.DataAnnotations;

namespace Lingo.Models
{
  public class GameWord
  {
      [Required]
      public int WordId { get; set; }
      public Word? Word { get; set; }
      [Required]
      public int GameId { get; set; }
      public Game? Game { get; set; }
  }
}