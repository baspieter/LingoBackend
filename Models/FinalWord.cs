namespace Lingo.Models
{
  public class FinalWord
  {
      public int Id { get; set; }
      public string Name { get; set; }

      public ICollection<Game> Games { get; set; }

      public FinalWord()
      {
        Name = "";
        Games = new List<Game> {};
      }
  }
}