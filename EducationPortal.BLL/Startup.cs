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
            
            this.Services.AddAutoMapper(mc =>
            {
                mc.AddProfile<MappingProfile>();
                mc.AddExpressionMapping();
            });

            this.Services.AddScoped<IAuthService, AuthService>();
            this.Services.AddScoped<IMaterialService, MaterialService>();
            this.Services.AddScoped<IUserService, UserService>();
            this.Services.AddScoped<ICourseService, CourseService>();
            
            return this.ServiceProvider = Services.BuildServiceProvider();
        }
    }
}
