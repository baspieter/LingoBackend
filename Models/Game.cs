using System.ComponentModel.DataAnnotations;
namespace Lingo.Models
{
  public enum Status
  {
    Active, Paused, Finished
  }
  public class Game
  {
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int Round { get; set; } = 0;
    
    [Required]
    public Status Status { get; init; } = Status.Active;

    [Required]
    public List<char>? FinalWordProgress { get; set; } = new();
    
    [Required]
    public int GreenBalls { get; set; } = 2;
    
    [Required]
    public int RedBalls { get; set; } = 2;
    public FinalWord? FinalWord { get; set; } = null;
    [Required]
    public int FinalWordId { get; set; }
    public IList<GameWord>? GameWords { get; set; }
  }
}
