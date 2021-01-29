using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;
using EducationPortal.BLL.Interfaces;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.Identity;
using EducationPortal.DAL.Interfaces;

namespace EducationPortal.BLL.Services
{
    public class AccountService : IAccountService
    {
        private AccountManager AccountManager { get; set; }

        public AccountService(AccountManager accountManager)
        {
            this.AccountManager = accountManager;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<OperationDetails> Create(AccountDTO accountDto)
        {
            try
            {
                await this.AccountManager.Register(accountDto.Login, accountDto.Password);
                return new OperationDetails(true, $"Registration succeded", "");

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
