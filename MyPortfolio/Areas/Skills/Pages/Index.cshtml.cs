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
    public class IndexModel : PageModel
    {
        private readonly MyPortfolio.Data.ApplicationDbContext _context;

        public IndexModel(MyPortfolio.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Skill> Skill { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Skill != null)
            {
                Skill = await _context.Skill.ToListAsync();
            }
        }
    }
}
