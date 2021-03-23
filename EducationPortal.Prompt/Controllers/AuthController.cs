using System.Threading.Tasks;
using AutoMapper;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Interfaces;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Models;
using EducationPortal.Prompt.ViewModels;
using EducationPortal.Prompt.Views.Home;

namespace EducationPortal.Prompt.Controllers
{
    public class AuthController
    {
        private IAuthService service;
        private IMapper mapper;

        public AuthController(IAuthService service)
        {
            this.service = service;
            
            this.mapper = new MapperConfiguration(cfg => cfg.CreateMap<AccountDto, AccountModel>().ReverseMap()).CreateMapper();
        }

        public async Task Login(AuthViewModel model)
        {
            var authAcc = await this.service.Login(model.Login, model.Password);

            // if (authAcc.Value != null)
            // {
            //     SessionStorage.AuthorizedUser = this.mapper.Map<AccountDto, AccountModel>(authAcc.Value);
            // }

            IndexPage.View(SessionStorage.AuthorizedUser);
        }

        public async Task Register(AuthViewModel model)
        {
            var operationDetails = await this.service.Register(model.Login, model.Password);

            // if (operationDetails.IsSucceeded)
            // {
            //     await this.Login(model);
            // }
        }

        public async Task Logout()
        {
            await this.service.LogOut();
            SessionStorage.AuthorizedUser = null;
            IndexPage.View(SessionStorage.AuthorizedUser);
        }
    }
}
