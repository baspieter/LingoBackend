using System.ComponentModel.DataAnnotations;

namespace Lingo.Models
{
  public class Word
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
  }
}