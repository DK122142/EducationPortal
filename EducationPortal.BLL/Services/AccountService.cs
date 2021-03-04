using System;
using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;
using EducationPortal.BLL.Interfaces;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.Identity;

namespace EducationPortal.BLL.Services
{
    public class AccountService : IAccountService
    {
        private IMapper mapper;

        private AccountManager AccountManager { get; }

        public AccountService(AccountManager accountManager)
        {
            this.AccountManager = accountManager;
            
            this.mapper = new MapperConfiguration(cfg => cfg.CreateMap<Account, AccountDTO>().ReverseMap()).CreateMapper();
        }
        
        public async Task<OperationDetails> RegisterAccount(AccountDTO accountDto)
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

        public AccountDTO Authenticate(AccountDTO userDto)
        {
            return this.mapper.Map<Account, AccountDTO>(
                this.AccountManager.Authenticate(userDto.Login, userDto.Password));
        }
    }
}
