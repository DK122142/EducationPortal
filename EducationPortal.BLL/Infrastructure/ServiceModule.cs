using System;
using EducationPortal.BLL.Interfaces;
using EducationPortal.BLL.Services;
using EducationPortal.DAL.FileStorage.Core;
using EducationPortal.DAL.FileStorage.Core.Internal;
using EducationPortal.DAL.FileStorage.Core.Internal.Interfaces;
using EducationPortal.DAL.FS;
using EducationPortal.DAL.FS.Interfaces;
using EducationPortal.DAL.Identity;
using EducationPortal.DAL.Infrastructure;
using EducationPortal.DAL.Interfaces;
using EducationPortal.DAL.Repositories.FileStorageRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.BLL.Infrastructure
{
    public static class ServiceModule
    {
        public static IServiceCollection Services { get; }

        public static IServiceProvider ServiceProvider { get; }
        
        static ServiceModule()
        {
            Services = new ServiceCollection();

            // Services.AddSingleton<IFileStorageSetInitializer, FileStorageSetInitializer>();
            // Services.AddSingleton<FSContext>();
            // Services.AddSingleton<IIdentityContext>(s =>
            //     new IdentityContext(s.GetRequiredService<IFileStorageSetInitializer>(), Config.StorageName));
            // Services.AddSingleton<IEducationPortalContext>(s =>
            //     new EducationPortalContext(s.GetRequiredService<IFileStorageSetInitializer>(), Config.StorageName));
            Services.AddSingleton(s => RepositoryContainer.ServiceProvider.GetRequiredService<AccountManager>());
            // Services.AddSingleton(typeof(GenericRepository<>));
            Services.AddSingleton<IUnitOfWork>(s =>
                RepositoryContainer.ServiceProvider.GetRequiredService<IUnitOfWork>());
            Services.AddSingleton<IAccountService, AccountService>();
            Services.AddSingleton<IArticleService, ArticleService>();
            Services.AddSingleton<IBookService, BookService>();
            Services.AddSingleton<IVideoService, VideoService>();
            // Services.AddSingleton<IMaterialService<VideoDTO>, MaterialService<Video, VideoDTO>>();
            // Services.AddSingleton<MaterialService<Video, VideoDTO>, VideoService>();

            ServiceProvider = Services.BuildServiceProvider();
        }
    }
}
