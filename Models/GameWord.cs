using System.ComponentModel.DataAnnotations;
using Lingo.Models;

namespace Lingo.Models
{
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
      
      public bool Finished { get; set; } = false;
  }
}