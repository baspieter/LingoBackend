using System.ComponentModel.DataAnnotations;

namespace Lingo.Models
{
    public enum LetterColor
    {
        Empty, Green, Red, Orange
    }
    public class GameWordProgress
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int GameWordId { get; set; }
        public GameWord? GameWord { get; set; }
        
        [Required]
        public List<string> WordProgress { get; set; } = new();
      
        [Required]
        public List<LetterColor> LetterProgress { get; init; } = new()
        { 
            LetterColor.Empty, LetterColor.Empty, LetterColor.Empty, LetterColor.Empty, LetterColor.Empty, LetterColor.Empty
        };
    }
}