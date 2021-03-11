using AutoMapper.Extensions.ExpressionMapping;
using EducationPortal.BLL.Interfaces;
using EducationPortal.BLL.Mapping;
using EducationPortal.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.WEB.MVC.DependencyInjection
{
    public static class BLL
    {
        public static void IncludeBLL(this IServiceCollection services)
        {
            services.IncludeDAL();

            services.AddAutoMapper(mc =>
            {
                mc.AddProfile<DtoMappingProfile>();
                mc.AddExpressionMapping();
            });

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ISkillService, SkillService>();
        }
    }
}
