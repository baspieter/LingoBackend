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
    public int Round { get; set; }

    [Required(ErrorMessage = "Required")]
    public Status Status { get; init; }
    public List<char> FinalWordProgress { get; set; }

    [Required(ErrorMessage = "Required")]
    public int GreenBalls { get; set; }

    [Required(ErrorMessage = "Required")]
    public int RedBalls { get; set; }
    public FinalWord FinalWord { get; set; }
    public IList<GameWord> GameWords { get; set; }
    public Game()
    {
      Round = 0;
      Status = Status.Active;
      GreenBalls = 2;
      RedBalls = 2;
    }
  }
}
