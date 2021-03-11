using EducationPortal.DAL.Interfaces;
using EducationPortal.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.WEB.MVC.DependencyInjection
{
    public static class DAL
    {
        public static void IncludeDAL(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
