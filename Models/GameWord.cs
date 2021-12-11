namespace Lingo.Models
{
  public class GameWord
  {
      public int WordId { get; set; }
      public Word Word { get; set; }
      public int GameId { get; set; }
      public Game Game { get; set; }


    public GameWord() 
    {
      Game = new Game();
      Word = new Word();
    }
  }
}