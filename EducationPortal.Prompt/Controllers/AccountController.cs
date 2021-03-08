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
            
            this.mapper = new MapperConfiguration(cfg => cfg.CreateMap<AccountDto, AccountModel>().ReverseMap()).CreateMapper();
        }

        public async Task Login(AccountModel model)
        {
            var authAcc = await this.accountService.Authenticate(model.Login, model.Password);

            if (authAcc != null)
            {
                SessionStorage.AuthorizedUser = this.mapper.Map<AccountDto, AccountModel>(authAcc);
            }

            IndexPage.View(SessionStorage.AuthorizedUser);
        }

        public async Task Register(AccountModel model)
        {
            var operationDetails = await this.accountService.RegisterAccount(model.Login, model.Password);

            if (operationDetails.Succeeded)
            {
                await this.Login(model);
            }
        }

        public void Logout()
        {
            SessionStorage.AuthorizedUser = null;
            IndexPage.View(SessionStorage.AuthorizedUser);
        }
    }
}
