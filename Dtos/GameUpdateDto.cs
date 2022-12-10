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
    public String FinalWordProgress { get; set; }
    [Required]
    public int Timer { get; set; }
    [Required]
    public FinalWord? FinalWord { get; set; }
    public IList<GameWord>? GameWords { get; set; }
  }
}
