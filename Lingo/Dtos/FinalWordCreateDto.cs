using System.ComponentModel.DataAnnotations;
namespace Lingo.Dtos
{
  public class FinalWordCreateDto
  {
    [Required]
    [StringLength(24, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 10)]
    public string? Name { get; set; }
  }
}