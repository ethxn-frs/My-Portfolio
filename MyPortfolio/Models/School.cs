using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models
{
    public class School
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 1)]
        [Required]
        [Display(Name = "Nom")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public virtual Image? Image { get; set; }
    }
}
