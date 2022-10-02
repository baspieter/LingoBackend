namespace Lingo.Dtos
{
    public class GameWordReadDto
    {
        public int Id { get; set; }
        public List<string> WordProgress { get; set; } = new();
        public List<int> WordLetterProgress { get; set; } = new();
        public bool Finished { get; set; } = false;
    }
}