using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models
{
    public class Project
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 1)]
        [Required]
        [Display(Name = "Nom")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int TimeSpent { get; set; }
        public string Context { get; set; }
        [Display(Name = "Etat")]
        public string State { get; set; }
        public string LanguageCode { get; set; }
        public string? GithubLink { get; set; }
        public virtual Image? Image { get; set; }
    }
}
