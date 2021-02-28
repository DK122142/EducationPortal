using EducationPortal.Prompt.Models;

namespace EducationPortal.Prompt.Infrastructure
{
    public static class SessionStorage
    {
        public static AccountModel AuthorizedUser { get; set; }
    }
}
