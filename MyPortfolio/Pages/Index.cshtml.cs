using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models;
using MyPortfolio.Areas.Certifications.Pages;
using MyPortfolio.Data ;

namespace MyPortfolio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MyPortfolio.Data.ApplicationDbContext _ctx;

        public IndexModel(ILogger<IndexModel> logger, MyPortfolio.Data.ApplicationDbContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        public IList<Certification> Certification{ get; set; }

        public async void OnGet()
        {
            //if (_ctx.Certifications != null)
            //{
            //    Certification = await _ctx.Certifications.Include(c => c.Image).ToListAsync();
            //}

        }
    }
}