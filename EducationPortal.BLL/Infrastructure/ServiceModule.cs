using System;
using EducationPortal.BLL.Interfaces;
using EducationPortal.BLL.Services;
using EducationPortal.DAL.Identity;
using EducationPortal.DAL.Infrastructure;
using EducationPortal.DAL.Interfaces;
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
            
            Services.AddSingleton(s => RepositoryContainer.ServiceProvider.GetRequiredService<AccountManager>());
            Services.AddSingleton<IUnitOfWork>(s =>
                RepositoryContainer.ServiceProvider.GetRequiredService<IUnitOfWork>());
            Services.AddSingleton<IAccountService, AccountService>();
            Services.AddSingleton<IArticleService, ArticleService>();
            Services.AddSingleton<IBookService, BookService>();
            Services.AddSingleton<IVideoService, VideoService>();

            ServiceProvider = Services.BuildServiceProvider();
        }
    }
}
