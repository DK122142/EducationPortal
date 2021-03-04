using System;
using EducationPortal.BLL.Infrastructure;
using EducationPortal.BLL.Interfaces;
using EducationPortal.Prompt.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Prompt.Infrastructure
{
    public static class Startup
    {
        public static IServiceCollection Services { get; }

        public static IServiceProvider ServiceProvider { get; }
        
        static Startup()
        {
            Services = new ServiceCollection();
            
            Services.AddTransient(s =>
                new AccountController(ServiceModule.ServiceProvider.GetRequiredService<IAccountService>()));
            Services.AddTransient(s =>
                new ArticleController(ServiceModule.ServiceProvider.GetRequiredService<IArticleService>()));
            Services.AddTransient(s =>
                new BookController(ServiceModule.ServiceProvider.GetRequiredService<IBookService>()));
            Services.AddTransient(s =>
                new VideoController(ServiceModule.ServiceProvider.GetRequiredService<IVideoService>()));

            ServiceProvider = Services.BuildServiceProvider();
        }
    }
}
