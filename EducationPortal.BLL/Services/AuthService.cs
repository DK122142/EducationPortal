using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;
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
        private readonly IMapper mapper;

        public AuthService(UserManager<Account> userManager, SignInManager<Account> signInManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }
        
        public async Task<OperationDetails<AccountDto>> Register(string username, string password)
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

            var result = await this.userManager.CreateAsync(account, password);
            
            if (result.Succeeded)
            {
                return new OperationDetails<AccountDto>(true, value: this.mapper.Map<AccountDto>(account));
            }
            else
            {
                return new OperationDetails<AccountDto>(false, property: string.Join(";", result.Errors));
            }
        }

        public async Task<OperationDetails<AccountDto>> Login(string username, string password)
        {
            var account = await this.userManager.FindByNameAsync(username);

            if (account != null)
            {
                var result = await this.signInManager.PasswordSignInAsync(account, password, true, false);

                if (result.Succeeded)
                {
                    return new OperationDetails<AccountDto>(true, value: new AccountDto
                    {
                        Login = account.UserName,
                        ProfileId = account.Profile.Id
                    });
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
