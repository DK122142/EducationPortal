using System;
using System.IO;
using EducationPortal.DAL.DbContexts;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.Interfaces;
using EducationPortal.DAL.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EducationPortal.DAL
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

            this.Services.AddDbContext<EducationPortalContext>(
                options =>
                {
                    options
                        .UseLazyLoadingProxies()
                        .UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"));
                });
            
            this.Services.AddIdentityCore<Account>()
                .AddEntityFrameworkStores<EducationPortalContext>();

            this.Services.AddHttpContextAccessor();
            this.Services.TryAddScoped<IAuthenticationSchemeProvider, AuthenticationSchemeProvider>();
            // Identity services
            this.Services.TryAddScoped<IUserValidator<Account>, UserValidator<Account>>();
            this.Services.TryAddScoped<IPasswordValidator<Account>, PasswordValidator<Account>>();
            this.Services.TryAddScoped<IPasswordHasher<Account>, PasswordHasher<Account>>();
            this.Services.TryAddScoped<ILookupNormalizer, UpperInvariantLookupNormalizer>();
            this.Services.TryAddScoped<IRoleValidator<Role>, RoleValidator<Role>>();
            // No interface for the error describer so we can add errors without rev'ing the interface
            this.Services.TryAddScoped<IdentityErrorDescriber>();
            this.Services.TryAddScoped<ISecurityStampValidator, SecurityStampValidator<Account>>();
            this.Services.TryAddScoped<ITwoFactorSecurityStampValidator, TwoFactorSecurityStampValidator<Account>>();
            this.Services.TryAddScoped<IUserClaimsPrincipalFactory<Account>, UserClaimsPrincipalFactory<Account, Role>>();
            this.Services.TryAddScoped<IUserStore<Account>, UserStore<Account>>();
            this.Services.TryAddScoped<UserManager<Account>>();
            this.Services.TryAddScoped<SignInManager<Account>>();
            this.Services.TryAddScoped<RoleManager<Role>>();

            this.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 1;

                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            // this.Services.AddScoped<IRepository<Article>, Repository<Article>>();
            // this.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            this.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            return this.ServiceProvider = this.Services.BuildServiceProvider();
        }
    }
}
