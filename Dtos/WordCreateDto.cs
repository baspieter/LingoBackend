using System.ComponentModel.DataAnnotations;
namespace Lingo.Dtos
{
  public class WordCreateDto
  {
    [Required]
    public string? Name { get; set; }
  }
}