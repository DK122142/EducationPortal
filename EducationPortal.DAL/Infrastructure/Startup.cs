using System;
using System.IO;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.Interfaces;
using EducationPortal.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.DAL.Infrastructure
{
    public class Startup
    {
        public IServiceCollection Services { get; private set; }

        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; }
        
        public Startup()
        {
            this.Configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public IServiceProvider ConfigureServices()
        {
            this.Services = new ServiceCollection();

            this.Services.AddDbContext<EF.EducationPortalContext>();

            this.Services.AddScoped<IUnitOfWork<Account>, UnitOfWork<Account>>();
            this.Services.AddScoped<IUnitOfWork<Article>, UnitOfWork<Article>>();
            this.Services.AddScoped<IUnitOfWork<Book>, UnitOfWork<Book>>();
            this.Services.AddScoped<IUnitOfWork<Course>, UnitOfWork<Course>>();
            this.Services.AddScoped<IUnitOfWork<Material>, UnitOfWork<Material>>();
            this.Services.AddScoped<IUnitOfWork<Profile>, UnitOfWork<Profile>>();
            this.Services.AddScoped<IUnitOfWork<ProfileSkill>, UnitOfWork<ProfileSkill>>();
            this.Services.AddScoped<IUnitOfWork<Skill>, UnitOfWork<Skill>>();
            this.Services.AddScoped<IUnitOfWork<Video>, UnitOfWork<Video>>();

            return this.ServiceProvider = this.Services.BuildServiceProvider();
        }
    }
}
