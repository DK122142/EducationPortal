using System;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FileStorage.Core;
using EducationPortal.DAL.FileStorage.Core.Internal;
using EducationPortal.DAL.FileStorage.Core.Internal.Interfaces;
using EducationPortal.DAL.FS;
using EducationPortal.DAL.FS.Interfaces;
using EducationPortal.DAL.Identity;
using EducationPortal.DAL.Interfaces;
using EducationPortal.DAL.Repositories.FileStorageRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.DAL.Infrastructure
{
    public static class Startup
    {
        public static IServiceCollection Services { get; }

        public static IServiceProvider ServiceProvider { get; }
        
        static Startup()
        {
            Services = new ServiceCollection();

            Services.AddDbContext<EF.EducationPortalContext>(options =>
                options.UseSqlServer(Config.GetConnectionString("DefaultConnection")));
            
            Services.AddSingleton<IFileStorageSetInitializer, FileStorageSetInitializer>();
            Services.AddTransient<FSContext>();

            Services.AddTransient<IIdentityContext>(s =>
                new IdentityContext(s.GetRequiredService<IFileStorageSetInitializer>(),
                    Config.GetConnectionString("FileStorage")));
            Services.AddSingleton<IEducationPortalContext>(s =>
                new EducationPortalContext(s.GetRequiredService<IFileStorageSetInitializer>(),
                    Config.GetConnectionString("FileStorage")));

            Services.AddTransient<AccountManager>();
            
            Services.AddSingleton<IRepository<Article>, ArticleRepository>();
            Services.AddSingleton<IRepository<Book>, BookRepository>();
            Services.AddSingleton<IRepository<Course>, CourseRepository>();
            Services.AddSingleton<IRepository<Profile>, ProfileRepository>();
            Services.AddSingleton<IRepository<Role>, RoleRepository>();
            Services.AddSingleton<IRepository<Skill>, SkillRepository>();
            Services.AddSingleton<IRepository<Video>, VideoRepository>();

            Services.AddScoped<IUnitOfWork, FSUnitOfWork>();

            ServiceProvider = Services.BuildServiceProvider();
        }
    }
}
