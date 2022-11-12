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
    public int Round { get; set; } = 1;
    
    [Required]
    public Status Status { get; set; } = Status.Active;

    [Required]
    public String FinalWordProgress { get; set; } = new String("");
    
    [Required]
    public int GreenBalls { get; set; } = 2;
    
    [Required]
    public int RedBalls { get; set; } = 2;
    public FinalWord FinalWord { get; set; }
    [Required]
    public ICollection<GameWord> GameWords { get; set; }
  }
}
