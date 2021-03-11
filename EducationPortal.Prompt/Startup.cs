using System;
using AutoMapper.Extensions.ExpressionMapping;
using EducationPortal.Prompt.Controllers;
using EducationPortal.Prompt.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Prompt
{
    public class Startup
    {
        public IServiceCollection Services { get; private set; }

        public IServiceProvider ServiceProvider { get; private set; }
        
        public IServiceProvider ConfigureServices()
        {
        //     var bll = new BLL.Startup();
        //     bll.ConfigureServices();
        //
        //     this.Services = bll.Services;

            this.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
                cfg.AddExpressionMapping();
            });

            this.Services.AddScoped<AuthController>();
            this.Services.AddScoped<MaterialController>();
            
            return this.ServiceProvider = Services.BuildServiceProvider();
        }
    }
}
