using System;
using EducationPortal.DAL.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EducationPortal.DAL.EF
{
    public class EducationPortalContextFactory : IDesignTimeDbContextFactory<EducationPortalContext>
    {
        public EducationPortalContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EducationPortalContext>();

            var connectionString = new Startup().Configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString,
                opts => opts.CommandTimeout((int) TimeSpan.FromMinutes(10).TotalSeconds));

            return new EducationPortalContext(optionsBuilder.Options);
        }
    }
}
