using System.ComponentModel.DataAnnotations;
using Lingo.Models;

namespace Lingo.Dtos
{
  public class GameCreateDto
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public int Round { get; set; }
    [Required]
    public Status Status { get; init; }
    [Required]
    public List<char>? FinalWordProgress { get; set; }
    [Required]
    public int Timer { get; set; }
    public FinalWord? FinalWord { get; set; }
    [Required]
    public int FinalWordId { get; set; }
    public IList<GameWord>? GameWords { get; set; }
  }
}