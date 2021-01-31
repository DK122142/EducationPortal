using System;
using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;
using EducationPortal.BLL.Interfaces;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.Identity;

namespace EducationPortal.BLL.Services
{
    public class AccountService : IAccountService
    {
        private AccountManager AccountManager { get; set; }

        public AccountService(AccountManager accountManager)
        {
            this.AccountManager = accountManager;
        }
        
        public async Task<OperationDetails> Create(AccountDTO accountDto)
        {
            try
            {
                await this.AccountManager.Register(accountDto.Login, accountDto.Password);
                return new OperationDetails(true, $"Registration succeeded", "");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new OperationDetails(false, "Registration failed", "");
            }
        }

        public Account Authenticate(AccountDTO userDto)
        {
            return this.AccountManager.Authenticate(userDto.Login, userDto.Password);
        }
    }
}
