using System.ComponentModel.DataAnnotations;
namespace Lingo.Dtos
{
  public class FinalWordCreateDto
  {
    [Required]
    public string? Name { get; set; }
  }
}