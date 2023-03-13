using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using MyPortfolio.Models;

namespace MyPortfolio.Areas.Skills.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly MyPortfolio.Data.ApplicationDbContext _context;

        public DetailsModel(MyPortfolio.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Skill Skill { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Skill == null)
            {
                return NotFound();
            }

            var skill = await _context.Skill.FirstOrDefaultAsync(m => m.Id == id);
            if (skill == null)
            {
                return NotFound();
            }
            else 
            {
                Skill = skill;
            }
            return Page();
        }
    }
}
