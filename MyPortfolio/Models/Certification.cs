using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models
{
    public class Certification
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 1)]
        [Required]
        [Display(Name = "Nom")]
        public string Name { get; set; }
        [Display(Name = "Etat")]
        public string State { get; set; }
        public virtual Image? Image { get; set; }
    }
}
