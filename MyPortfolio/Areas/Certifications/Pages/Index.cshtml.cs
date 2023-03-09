 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using MyPortfolio.Models;

namespace MyPortfolio.Areas.Certifications.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MyPortfolio.Data.ApplicationDbContext ctx;

        public IndexModel(MyPortfolio.Data.ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        public IList<Certification> Certification { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (ctx.Certifications != null)
            {
                Certification = await ctx.Certifications.Include(c => c.Image).ToListAsync();
            }
        }
    }
}
