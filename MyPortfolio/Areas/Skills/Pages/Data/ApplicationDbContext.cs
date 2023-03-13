using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models;

namespace MyPortfolio.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MyPortfolio.Models.Certification> Certifications { get; set; }
        public DbSet<MyPortfolio.Models.Image> Images { get; set; }
        public DbSet<MyPortfolio.Models.Project> Project { get; set; }
        public DbSet<MyPortfolio.Models.School> School { get; set; }
        public DbSet<MyPortfolio.Models.Skill> Skill { get; set; }
    }
}