using System.ComponentModel.DataAnnotations;
using Lingo.Models;

namespace Lingo.Dtos
{
  public class GameUpdateDto
  {
    [Required(ErrorMessage = "Required")]
    public int Round { get; set; }

    [Required(ErrorMessage = "Required")]
    public Status Status { get; init; }
    public List<char>? FinalWordProgress { get; set; }

    [Required(ErrorMessage = "Required")]
    public int GreenBalls { get; set; }

    [Required(ErrorMessage = "Required")]
    public int RedBalls { get; set; }
  }
}
