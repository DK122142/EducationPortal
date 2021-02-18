using System;
using EducationPortal.BLL.Interfaces;
using EducationPortal.BLL.Services;
using EducationPortal.DAL.FileStorage.Core;
using EducationPortal.DAL.FileStorage.Core.Internal;
using EducationPortal.DAL.FileStorage.Core.Internal.Interfaces;
using EducationPortal.DAL.FS;
using EducationPortal.DAL.FS.Interfaces;
using EducationPortal.DAL.Identity;
using EducationPortal.DAL.Interfaces;
using EducationPortal.DAL.Repositories.FileStorageRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.BLL.Infrastructure
{
    public static class ServiceModule
    {
        public static IServiceCollection Services { get; set; }

        public static IServiceProvider ServiceProvider { get; set; }

        // TODO separate
        private static readonly string storageName = "EducationPortal";

        static ServiceModule()
        {
            Services = new ServiceCollection();

            Services.AddSingleton<IFileStorageSetInitializer, FileStorageSetInitializer>();
            Services.AddSingleton<FSContext>();
            Services.AddSingleton<IIdentityContext>(s =>
                new IdentityContext(s.GetRequiredService<IFileStorageSetInitializer>(), storageName));
            Services.AddSingleton<IEducationPortalContext>(s =>
                new EducationPortalContext(s.GetRequiredService<IFileStorageSetInitializer>(), storageName));
            Services.AddSingleton<AccountManager>();
            // Services.AddSingleton(typeof(GenericRepository<>));
            Services.AddSingleton<IAccountService, AccountService>();
            Services.AddSingleton<IUnitOfWork, FSUnitOfWork>();
            Services.AddSingleton<IVideoService, VideoService>();
            
            ServiceProvider = Services.BuildServiceProvider();
        }
    }
}
