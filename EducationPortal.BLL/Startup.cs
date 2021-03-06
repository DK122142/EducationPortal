using System;
using EducationPortal.BLL.Interfaces;
using EducationPortal.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.BLL
{
    public class Startup
    {
        public IServiceCollection Services { get; private set; }

        public IServiceProvider ServiceProvider { get; private set; }

        public IServiceProvider ConfigureServices()
        {
            var dal = new DAL.Startup();
            dal.ConfigureServices();

            this.Services = dal.Services;
            
            Services.AddTransient<IAccountService, AccountService>();
            // Services.AddTransient<IArticleService, ArticleService>();
            // Services.AddTransient<IBookService, BookService>();
            // Services.AddTransient<IVideoService, VideoService>();

            return this.ServiceProvider = Services.BuildServiceProvider();
        }
    }
}
