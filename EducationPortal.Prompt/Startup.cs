using System;
using EducationPortal.BLL.Interfaces;
using EducationPortal.Prompt.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Prompt
{
    public class Startup
    {
        public IServiceCollection Services { get; private set; }

        public IServiceProvider ServiceProvider { get; private set; }
        
        
        public IServiceProvider ConfigureServices()
        {
            var bll = new BLL.Startup();
            bll.ConfigureServices();

            this.Services = bll.Services;

            this.Services.AddScoped<AccountController>();

            // Services.AddTransient(s =>
            //     new ArticleController(BLL.Startup.ServiceProvider.GetRequiredService<IArticleService>()));
            // Services.AddTransient(s =>
            //     new BookController(BLL.Startup.ServiceProvider.GetRequiredService<IBookService>()));
            // Services.AddTransient(s =>
            //     new VideoController(BLL.Startup.ServiceProvider.GetRequiredService<IVideoService>()));

            return this.ServiceProvider = Services.BuildServiceProvider();
        }
    }
}
