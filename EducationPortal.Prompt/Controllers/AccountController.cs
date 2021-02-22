using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Interfaces;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Models;
using EducationPortal.Prompt.Views.Home;

namespace EducationPortal.Prompt.Controllers
{
    public class AccountController
    {
        private IAccountService accountService;
        private IMapper mapper;

        public AccountController(IAccountService service)
        {
            this.accountService = service;
            
            this.mapper = new MapperConfiguration(cfg => cfg.CreateMap<AccountDTO, AccountModel>().ReverseMap()).CreateMapper();
        }

        public void Login(AccountModel model)
        {
            var authAcc = this.accountService.Authenticate(this.mapper.Map<AccountModel, AccountDTO>(model));

            if (authAcc != null)
            {
                Logout();

                SessionProvider.AuthorizedUser = this.mapper.Map<AccountDTO, AccountModel>(authAcc);
            }

            Home.Show();
        }

        public async Task Register(AccountModel model)
        {
            var operationDetails = await this.accountService.RegisterAccount(this.mapper.Map<AccountModel, AccountDTO>(model));

            if (operationDetails.Succeeded)
            {
                this.Login(model);
            }

            Home.Show($"{operationDetails.Message}, {operationDetails.Property}");
        }

        public void Logout()
        {
            SessionProvider.AuthorizedUser = null;
        }
    }
}
