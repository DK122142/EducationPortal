using System;
using EducationPortal.BLL.Infrastructure;
using EducationPortal.BLL.Interfaces;
using EducationPortal.Prompt.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Prompt.Infrastructure
{
    public static class Startup
    {
        public static IServiceCollection Services { get; }

        public static IServiceProvider ServiceProvider { get; }
        
        static Startup()
        {
            Services = new ServiceCollection();
            
            Services.AddTransient<AccountController>(s =>
                new AccountController(ServiceModule.ServiceProvider.GetRequiredService<IAccountService>()));

            ServiceProvider = Services.BuildServiceProvider();
        }
    }
}
