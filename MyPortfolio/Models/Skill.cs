using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models
{
    public class Skill
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 1)]
        [Required]
        [Display(Name = "Nom")]
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Date { get; set; }
        public virtual Image? Image { get; set; }

    }
}
