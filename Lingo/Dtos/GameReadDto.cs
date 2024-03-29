using Lingo.Models;

namespace Lingo.Dtos
{
  public class GameReadDto
  {
    public int Id { get; set; }
    public int Round { get; set; }
    public Status Status { get; init; }
    public String FinalWordProgress { get; set; }
    public int Timer { get; set; }
  }
}