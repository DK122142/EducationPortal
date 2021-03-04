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
            
            Services.AddTransient(s => RepositoryContainer.ServiceProvider.GetRequiredService<AccountManager>());
            Services.AddTransient<IUnitOfWork>(s =>
                RepositoryContainer.ServiceProvider.GetRequiredService<IUnitOfWork>());
            Services.AddTransient<IAccountService, AccountService>();
            Services.AddTransient<IArticleService, ArticleService>();
            Services.AddTransient<IBookService, BookService>();
            Services.AddTransient<IVideoService, VideoService>();

            ServiceProvider = Services.BuildServiceProvider();
        }
    }
}
