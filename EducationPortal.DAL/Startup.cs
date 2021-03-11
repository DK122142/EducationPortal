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
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IConfiguration Configuration { get; }
        
        static Startup()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.IncludeServices();

            return ServiceProvider = services.BuildServiceProvider();
        }

        public static void IncludeServices(this IServiceCollection services)
        {
            services.AddDbContext<EducationPortalContext>(
                options =>
                {
                    options
                        .UseLazyLoadingProxies()
                        .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                });
            
            services.AddIdentityCore<Account>()
                .AddEntityFrameworkStores<EducationPortalContext>();

            services.AddHttpContextAccessor();
            services.TryAddScoped<IAuthenticationSchemeProvider, AuthenticationSchemeProvider>();
            // Identity services
            services.TryAddScoped<IUserValidator<Account>, UserValidator<Account>>();
            services.TryAddScoped<IPasswordValidator<Account>, PasswordValidator<Account>>();
            services.TryAddScoped<IPasswordHasher<Account>, PasswordHasher<Account>>();
            services.TryAddScoped<ILookupNormalizer, UpperInvariantLookupNormalizer>();
            services.TryAddScoped<IRoleValidator<IdentityRole>, RoleValidator<IdentityRole>>();
            // No interface for the error describer so we can add errors without rev'ing the interface
            services.TryAddScoped<IdentityErrorDescriber>();
            services.TryAddScoped<ISecurityStampValidator, SecurityStampValidator<Account>>();
            services.TryAddScoped<ITwoFactorSecurityStampValidator, TwoFactorSecurityStampValidator<Account>>();
            services.TryAddScoped<IUserClaimsPrincipalFactory<Account>, UserClaimsPrincipalFactory<Account, IdentityRole>>();
            services.TryAddScoped<IUserStore<Account>, UserStore<Account>>();
            services.TryAddScoped<UserManager<Account>>();
            services.TryAddScoped<SignInManager<Account>>();
            services.TryAddScoped<RoleManager<IdentityRole>>();

            services.Configure<IdentityOptions>(options =>
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

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
