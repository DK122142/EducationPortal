using System;
using AutoMapper.Extensions.ExpressionMapping;
using EducationPortal.BLL.Interfaces;
using EducationPortal.BLL.Mapping;
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

            this.Services.AddAutoMapper(typeof(Startup));

            this.Services.AddAutoMapper(mc =>
            {
                mc.AddProfile(typeof(MappingProfile));
                mc.AddExpressionMapping();
            });

            this.Services.AddScoped<IAccountService, AccountService>();
            this.Services.AddScoped<IArticleService, ArticleService>();
            this.Services.AddScoped<IMaterialService, MaterialService>();

            // Services.AddTransient<IBookService, BookService>();
            // Services.AddTransient<IVideoService, VideoService>();

            return this.ServiceProvider = Services.BuildServiceProvider();
        }
    }
}
