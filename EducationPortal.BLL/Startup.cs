using System;
using AutoMapper.Extensions.ExpressionMapping;
using EducationPortal.BLL.Interfaces;
using EducationPortal.BLL.Mapping;
using EducationPortal.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.BLL
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.IncludeServices();

            return ServiceProvider = services.BuildServiceProvider();
        }

        public static void IncludeServices(this IServiceCollection services)
        {
            DAL.Startup.IncludeServices(services);

            services.AddAutoMapper(mc =>
            {
                mc.AddProfile<DtoMappingProfile>();
                mc.AddExpressionMapping();
            });

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IMaterialService, MaterialService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICourseService, CourseService>();
        }
    }
}
