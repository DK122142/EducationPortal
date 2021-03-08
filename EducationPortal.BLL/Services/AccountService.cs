using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;
using EducationPortal.BLL.Interfaces;
using EducationPortal.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace EducationPortal.BLL.Services
{
    public class AccountService : IAccountService
    {        
        private readonly UserManager<Account> userManager;
        private readonly SignInManager<Account> signInManager;

        public AccountService(UserManager<Account> userManager, SignInManager<Account> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        
        public async Task<OperationDetails> RegisterAccount(string username, string password)
        {
            
            var newAccount = new Account
            {
                UserName = username,
            };

            var profile = new Profile
            {
                Account = newAccount,
                Name = newAccount.UserName,
            };
            
            newAccount.Profile = profile;

            var result = await this.userManager.CreateAsync(newAccount, password);
            
            if (result.Succeeded)
            {
                return new OperationDetails(true, $"Registration successful", string.Join(";", result.Errors));
            }
            else
            {
                return new OperationDetails(false, $"Registration failed", string.Join(";", result.Errors));
            }
        }

        public async Task<AccountDto> Authenticate(string username, string password)
        {
            var account = await this.userManager.FindByNameAsync(username);

            if (account != null)
            {
                var result = await this.signInManager.CheckPasswordSignInAsync(account, password, false);

                if (result.Succeeded)
                {
                    return new AccountDto
                    {
                        Login = account.UserName
                    };
                }
            }

            return default;
        }

        public async Task LogOut()
        {
            await this.signInManager.SignOutAsync();
        }
    }
}
