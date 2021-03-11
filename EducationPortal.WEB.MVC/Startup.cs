using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Extensions.ExpressionMapping;
using EducationPortal.BLL;
using EducationPortal.DAL.DbContexts;
using EducationPortal.DAL.Entities;
using EducationPortal.WEB.MVC.DependencyInjection;
using EducationPortal.WEB.MVC.Mapping;
using Microsoft.EntityFrameworkCore;

namespace EducationPortal.WEB.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EducationPortalContext>(opt =>
            {
                opt
                    .UseLazyLoadingProxies()
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            
            services.AddIdentity<Account, Role>()
                .AddEntityFrameworkStores<EducationPortalContext>();

            services.IncludeBLL();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<ModelMappingProfile>();
                cfg.AddExpressionMapping();
            });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
