using EducationPortal.BLL.Interfaces;
using EducationPortal.Prompt.Controllers;
using EducationPortal.Prompt.Models;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Prompt.Infrastructure
{
    public static class SessionStorage
    {
        public static AccountModel AuthorizedUser { get; set; }
    }
}
