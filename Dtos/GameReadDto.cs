using System.ComponentModel.DataAnnotations;
using Lingo.Models;

namespace Lingo.Dtos
{
  public class GameReadDto
  {
    public int Round { get; set; }
    public Status Status { get; init; }
    public List<char> FinalWordProgress { get; set; }
    public int GreenBalls { get; set; }
    public int RedBalls { get; set; }
  }
}