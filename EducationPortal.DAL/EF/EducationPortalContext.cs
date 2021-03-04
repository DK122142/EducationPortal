using EducationPortal.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EducationPortal.DAL.EF
{
    public class EducationPortalContext : IdentityDbContext<Account>
    {
        public DbSet<Profile> Profiles { get; set; }
        
        public DbSet<Material> Materials { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public EducationPortalContext(DbContextOptions<EducationPortalContext> options) : base(options)
        {
            Database.EnsureCreated();
        }


        
    }
}
