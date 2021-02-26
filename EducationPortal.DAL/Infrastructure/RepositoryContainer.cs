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
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.DAL.Infrastructure
{
    public static class RepositoryContainer
    {
        public static IServiceCollection Services { get; }

        public static IServiceProvider ServiceProvider { get; }
        
        static RepositoryContainer()
        {
            Services = new ServiceCollection();
            
            Services.AddSingleton<IFileStorageSetInitializer, FileStorageSetInitializer>();
            Services.AddScoped<FSContext>();

            Services.AddScoped<IIdentityContext>(s =>
                new IdentityContext(s.GetRequiredService<IFileStorageSetInitializer>(),
                    Config.GetConnectionString("FileStorage")));
            Services.AddSingleton<IEducationPortalContext>(s =>
                new EducationPortalContext(s.GetRequiredService<IFileStorageSetInitializer>(),
                    Config.GetConnectionString("FileStorage")));

            Services.AddSingleton<AccountManager>();
            
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
