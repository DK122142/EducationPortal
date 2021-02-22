using EducationPortal.BLL.Infrastructure;
using EducationPortal.BLL.Interfaces;
using EducationPortal.Prompt.Controllers;
using EducationPortal.Prompt.Models;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Prompt.Infrastructure
{
    public static class SessionProvider
    {
        public static AccountModel AuthorizedUser { get; set; }

        // TODO: remove
        public static AccountController AccountController { get; set; } =
            new AccountController(ServiceModule.ServiceProvider.GetRequiredService<IAccountService>());

        public static VideoController VideoController { get; set; } =
            new VideoController(ServiceModule.ServiceProvider.GetRequiredService<IVideoService>());

        // public static IServiceProvider ServiceProvider { get; set; } = ServiceModule.ServiceProvider;
    }
}
