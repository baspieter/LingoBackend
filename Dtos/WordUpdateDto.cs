using System.ComponentModel.DataAnnotations;
namespace Lingo.Dtos
{
  public class WordUpdateDto
  {
    [Required]
    public string? Name { get; set; }
  }
}