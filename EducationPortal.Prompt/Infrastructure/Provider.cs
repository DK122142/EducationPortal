using System;
using EducationPortal.BLL.Infrastructure;
using EducationPortal.Prompt.Controllers;
using EducationPortal.Prompt.Models;

namespace EducationPortal.Prompt.Infrastructure
{
    public static class Provider
    {
        public static AccountModel AuthorizedUser { get; set; } = default;

        public static AccountController AccountController { get; set; } = new AccountController();

        public static VideoController VideoController { get; set; } = new VideoController();

        // public static IServiceProvider ServiceProvider { get; set; } = ServiceModule.ServiceProvider;
    }
}
