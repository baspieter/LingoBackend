using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Lingo.Models;

namespace Lingo.Models
{
    public class WordEntry
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(6, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string? Name { get; set; }

        [Required]
        public GameWord GameWord { get; set; }
    }
}