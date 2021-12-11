using System.ComponentModel.DataAnnotations;
using Lingo.Models;

namespace Lingo.Dtos
{
  public class GameCreateDto
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

  }
}