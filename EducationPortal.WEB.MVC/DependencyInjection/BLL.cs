using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IMaterialService, MaterialService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICourseService, CourseService>();
        }
    }
}
