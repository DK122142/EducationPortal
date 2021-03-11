using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace EducationPortal.BLL.Interfaces
{
    public interface IAuthService
    {
        public Task<IdentityResult> Register(string username, string password);

        public Task<SignInResult> Login(string username, string password, bool rememberMe = false);

        public Task LogOut();
    }
}
