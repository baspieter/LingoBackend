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

    [Required(ErrorMessage = "Required")]
    public int Round { get; set; } = 0;

    [Required(ErrorMessage = "Required")]
    public Status Status { get; init; } = Status.Active;
    public List<char>? FinalWordProgress { get; set; }

    [Required(ErrorMessage = "Required")]
    public int GreenBalls { get; set; } = 2;

    [Required(ErrorMessage = "Required")]
    public int RedBalls { get; set; } = 2;
    public FinalWord? FinalWord { get; set; }
    public IList<GameWord>? GameWords { get; set; }
  }
}
