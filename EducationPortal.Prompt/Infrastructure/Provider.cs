using EducationPortal.BLL.Infrastructure;
using EducationPortal.BLL.Interfaces;
using EducationPortal.Prompt.Controllers;
using EducationPortal.Prompt.Models;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Prompt.Infrastructure
{
    // TODO: update
    public static class Provider
    {
        public static AccountModel AuthorizedUser { get; set; } = default;

        public static AccountController AccountController { get; set; } =
            new AccountController(ServiceModule.ServiceProvider.GetRequiredService<IAccountService>());

        public static VideoController VideoController { get; set; } =
            new VideoController(ServiceModule.ServiceProvider.GetRequiredService<IVideoService>());

        // public static IServiceProvider ServiceProvider { get; set; } = ServiceModule.ServiceProvider;
    }
}
