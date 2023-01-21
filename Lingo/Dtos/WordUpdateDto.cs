using System.ComponentModel.DataAnnotations;
namespace Lingo.Dtos
{
  public class WordUpdateDto
  {
    [Required]
    [StringLength(6, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
    public string? Name { get; set; }
  }
}