using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using MyPortfolio.Models;

namespace MyPortfolio.Areas.Schools.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly MyPortfolio.Data.ApplicationDbContext _context;

        public DeleteModel(MyPortfolio.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public School School { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.School == null)
            {
                return NotFound();
            }

            var school = await _context.School.FirstOrDefaultAsync(m => m.Id == id);

            if (school == null)
            {
                return NotFound();
            }
            else 
            {
                School = school;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.School == null)
            {
                return NotFound();
            }
            var school = await _context.School.FindAsync(id);

            if (school != null)
            {
                School = school;
                _context.School.Remove(School);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
