using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using MyPortfolio.Models;
using MyPortfolio.Services;

namespace MyPortfolio.Areas.Certifications.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly MyPortfolio.Data.ApplicationDbContext ctx;
        private readonly ImageService imageService;

        public DeleteModel(MyPortfolio.Data.ApplicationDbContext ctx, ImageService imageService)
        {
            this.ctx = ctx;
            this.imageService = imageService;
        }

        [BindProperty]
      public Certification Certification { get; set; }
      public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? hasErrorMessage = false)
        {
            if (id == null || ctx.Certifications == null)
            {
                return NotFound();
            }

            var certification = await ctx.Certifications.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (certification == null)
            {
                return NotFound();
            }

            //if (hasErrorMessage.GetValueOrDefault())
            //{
            //    ErrorMessage =
            //        $"Une erreur est survenue lors de la tentative de la suppression de {Certification.Name} ({Certification.Id})";
            //}

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || ctx.Certifications == null)
            {
                return NotFound();
            }

            var certificationToDelete =
                await ctx.Certifications.Include(c => c.Image).FirstOrDefaultAsync(c => c.Id == id);

            if (certificationToDelete == null)
            {
                return NotFound();
            }

            try
            {
                throw new Exception("");
                imageService.DeleteUploadedFile(certificationToDelete.Image);
                ctx.Certifications.Remove(Certification);
                await ctx.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("./Delete", new {id, hasErrorMessage = true });
            }
             
        }
    }
}
