using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using MyPortfolio.Models;
using MyPortfolio.Services;

namespace MyPortfolio.Areas.Certifications.Pages
{
    public class EditModel : PageModel
    {
        private readonly MyPortfolio.Data.ApplicationDbContext ctx;
        private readonly ImageService imageService;

        public EditModel(MyPortfolio.Data.ApplicationDbContext ctx, ImageService imageService)
        {
            this.ctx = ctx;
            this.imageService = imageService;
        }

        [BindProperty]
        public Certification Certification { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || ctx.Certifications == null)
            {
                return NotFound();
            }

            var certification =  await ctx.Certifications
                .Include(c => c.Image)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certification == null)
            {
                return NotFound();
            }
            Certification = certification;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var certificationToUpdate = await ctx.Certifications
                .Include(c => c.Image)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (certificationToUpdate == null)
            {
                return NotFound();
            }

            var uploadedImage = Certification.Image;

            if (null != uploadedImage)
            {
                uploadedImage = await imageService.UploadAsync(uploadedImage);

                if (certificationToUpdate.Image != null)
                {
                    imageService.DeleteUploadedFile(certificationToUpdate.Image);
                    certificationToUpdate.Image.Name = uploadedImage.Name;
                    certificationToUpdate.Image.Path = uploadedImage.Path;
                }
                else
                {
                    certificationToUpdate.Image = uploadedImage;
                }
            }

            if (await TryUpdateModelAsync(certificationToUpdate, "Certification", c => c.Name, c => c.State))
            {
                await ctx.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool CertificationExists(int id)
        {
          return (ctx.Certifications?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
