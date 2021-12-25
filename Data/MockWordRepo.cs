using Lingo.Models;

namespace Lingo.Data{
  public class MockWordRepo : IWordRepo
  {
    public void CreateWord(Word word)
    {
      throw new NotImplementedException();
    }

    public void DeleteWord(Word word)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Word> GetAllWords()
    {
      var words = new List<Word>
      {
        new Word{Id=0, Name="Auto"},
        new Word{Id=1, Name="Fiets"},
        new Word{Id=2, Name="Trein"}
      };

      return words;
    }

    public Word GetFirstRecord()
    {
      throw new NotImplementedException();
    }

    public Word GetWordById(int id)
    {
      return new Word{Id=0, Name="Auto"};
    }

    public bool SaveChanges()
    {
      throw new NotImplementedException();
    }

    public void UpdateWord(Word word)
    {
      throw new NotImplementedException();
    }
  }
}