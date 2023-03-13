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
    public class IndexModel : PageModel
    {
        private readonly MyPortfolio.Data.ApplicationDbContext _context;

        public IndexModel(MyPortfolio.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<School> School { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.School != null)
            {
                School = await _context.School.ToListAsync();
            }
        }
    }
}
