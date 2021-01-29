using System;
using EducationPortal.BLL.DTO;
using EducationPortal.Prompt.Controllers;
using EducationPortal.Prompt.Interfaces;

namespace EducationPortal.Prompt.Infrastructure
{
    public static class Provider
    {
        public static AccountDTO AuthorizedUser { get; set; } = default;

        public static AccountController AccountController { get; set; } = new AccountController();

        public static VideoController VideoController { get; set; } = new VideoController();

        public static IServiceProvider ServiceProvider { get; set; } = AppContext.ServiceProvider;
    }
}
