using System;
using EducationPortal.BLL.Interfaces;
using EducationPortal.BLL.Services;
using EducationPortal.DAL.FileStorage.Core;
using EducationPortal.DAL.FileStorage.Core.Internal;
using EducationPortal.DAL.FileStorage.Core.Internal.Interfaces;
using EducationPortal.DAL.FS;
using EducationPortal.DAL.Identity;
using EducationPortal.Prompt.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Prompt
{
    public static class AppContext
    {
        public static IServiceCollection Services { get; set; }
        public static IServiceProvider ServiceProvider { get; set; }

        // private static readonly IServiceCreator serviceCreator = new ServiceCreator();
        
        // public static IAccountService CreateAccountService()
        // {
        //     return serviceCreator.CreateAccountService();
        // }

        static AppContext()
        {
            Services = new ServiceCollection();
            
            // Services.AddSingleton<IFileStorageSetInitializer, FileStorageSetInitializer>();
            // Services.AddSingleton<FSContext>();
            Services.AddSingleton<IdentityContext>();
            Services.AddSingleton<AccountManager>();
            Services.AddSingleton<IAccountService, AccountService>();
            
            ServiceProvider = Services.BuildServiceProvider();
        }
    }
}
