using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyPortfolio.Data;
using MyPortfolio.Models;
using MyPortfolio.Services;

namespace MyPortfolio.Areas.Certifications.Pages
{
    public class CreateModel : PageModel
    {
        private readonly MyPortfolio.Data.ApplicationDbContext ctx;
        private readonly ImageService imageService;

        public CreateModel(MyPortfolio.Data.ApplicationDbContext ctx, ImageService imageService)
        {
            this.ctx = ctx;
            this.imageService = imageService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public Certification Certification { get; set; } = new();

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyCertification = new Certification();

            if (null != Certification.Image)
                emptyCertification.Image = await imageService.UploadAsync(Certification.Image);
            
            if (await TryUpdateModelAsync(emptyCertification, "Certification", c => c.Name, c => c.State))
            {
                ctx.Certifications.Add(emptyCertification);
                await ctx.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
