using Lingo.Models;

namespace Lingo.Dtos
{
    public class GameWordReadDto
    {
        public int Id { get; set; }
        public IList<WordEntry>? WordEntries { get; set; }
        public bool Finished { get; set; } = false;
    }
}