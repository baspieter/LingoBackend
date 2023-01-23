using System.ComponentModel.DataAnnotations;

namespace Lingo.Models
{
  public class FinalWord
  {
      [Key]
      public int Id { get; set; }

      [Required]
      [StringLength(24, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 10)]
      public string? Name { get; set; }

      public ICollection<Game>? Games { get; set; }
  }
}