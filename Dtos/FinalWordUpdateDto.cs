using System.ComponentModel.DataAnnotations;
namespace Lingo.Dtos
{
  public class FinalWordUpdateDto
  {
    [Required]
    public string? Name { get; set; }
  }
}