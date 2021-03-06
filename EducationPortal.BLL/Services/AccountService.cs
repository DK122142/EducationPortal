using System;
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
    public class AccountService : IAccountService
    {        
        private readonly UserManager<Account> userManager;
        private readonly SignInManager<Account> signInManager;
        private IMapper mapper;

        public AccountService(UserManager<Account> userManager, SignInManager<Account> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            
            this.mapper = new MapperConfiguration(cfg => cfg.CreateMap<Account, AccountDto>().ReverseMap()).CreateMapper();
        }
        
        public async Task<OperationDetails> RegisterAccount(string username, string password)
        {
            
            Account newAccount = new Account
            {
                UserName = username
            };

            var result = await this.userManager.CreateAsync(newAccount, password);

            if (result.Succeeded)
            {
                return new OperationDetails(true, $"Registration succeeded", "");
            }
            else
            {
                return new OperationDetails(false, $"Registration failed", string.Join(";", result.Errors));
            }
        }

        public async Task<AccountDto> Authenticate(string username, string password)
        {
            var account = await this.userManager.FindByNameAsync(username);

            var result = await this.signInManager.CheckPasswordSignInAsync(account, password, false);

            if (result.Succeeded)
            {
                return new AccountDto
                {
                    Id = account.Id,
                    UserName = account.UserName
                };
            }

            return default;
        }

        public async Task LogOut()
        {
            await this.signInManager.SignOutAsync();
        }
    }
}
