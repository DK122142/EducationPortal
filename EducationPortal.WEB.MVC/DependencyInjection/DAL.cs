using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.DAL.Interfaces;
using EducationPortal.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.WEB.MVC.DependencyInjection
{
    public static class DAL
    {
        public static void IncludeDAL(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
