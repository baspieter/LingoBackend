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
    // public int Round { get; set; }
    // public Status Status { get; init; }
    // public int Score { get; set; }

    public List<int> WordProgress { get; set; }

    // public Game()
    // {
    //   Round = 0;
    //   Status = Status.Active;
    //   Score = 0;
    // }
  }
}