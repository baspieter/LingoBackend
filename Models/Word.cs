using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Lingo.Models
{
  public class Word
  {
    [Key]
    public int Id { get; set; }

    [RegularExpression(@"^.{6,}$", ErrorMessage = "Minimum 6 characters required")]
    [Required(ErrorMessage = "Required")]
    [StringLength(6, MinimumLength = 6, ErrorMessage = "Maximum 6 characters")]
    public string? Name { get; set; }

    public IList<GameWord>? GameWords { get; set; }

    public static implicit operator DbSet<object>(Word v)
    {
      throw new NotImplementedException();
    }
  }
}