using System.Threading.Tasks;
using EducationPortal.BLL.Interfaces;
using EducationPortal.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Profile = EducationPortal.DAL.Entities.Profile;

namespace EducationPortal.BLL.Services
{
    public class AuthService : IAuthService
    {        
        private readonly UserManager<Account> userManager;
        private readonly SignInManager<Account> signInManager;

        public AuthService(UserManager<Account> userManager, SignInManager<Account> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        
        public async Task<IdentityResult> Register(string username, string password)
        {
            var account = new Account
            {
                UserName = username,
            };

            var profile = new Profile
            {
                Account = account,
                Name = account.UserName,
            };
            
            account.Profile = profile;

            return await this.userManager.CreateAsync(account, password);
        }

        public async Task<SignInResult> Login(string username, string password, bool rememberMe = false)
        {
            var account = await this.userManager.FindByNameAsync(username);

            if (account != null)
            {
                return await this.signInManager.PasswordSignInAsync(account, password, rememberMe, false);
            }

            return default;
        }

        public async Task LogOut()
        {
            await this.signInManager.SignOutAsync();
        }
    }
}
