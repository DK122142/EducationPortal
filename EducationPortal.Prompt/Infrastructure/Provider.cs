using EducationPortal.BLL.DTO;
using EducationPortal.Prompt.Controllers;

namespace EducationPortal.Prompt.Infrastructure
{
    public static class Provider
    {
        public static AccountDTO AuthorizedUser { get; set; } = default;

        public static AccountController AccountController { get; set; } = new AccountController();
    }
}
