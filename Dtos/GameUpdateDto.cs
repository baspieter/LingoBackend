using System.ComponentModel.DataAnnotations;
using Lingo.Models;

namespace Lingo.Dtos
{
  public class GameUpdateDto
  {
    [Required]
    public int Round { get; set; }
    [Required]
    public Status Status { get; init; }
    [Required]
    public List<char>? FinalWordProgress { get; set; }
    [Required]
    public int GreenBalls { get; set; }
    [Required]
    public int RedBalls { get; set; }
    [Required]
    public FinalWord? FinalWord { get; set; }
    public IList<GameWord>? GameWords { get; set; }
  }
}
