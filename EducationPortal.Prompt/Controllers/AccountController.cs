using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.BLL.Infrastructure;
using EducationPortal.BLL.Interfaces;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Models;
using EducationPortal.Prompt.Views.Home;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Prompt.Controllers
{
    public class AccountController
    {
        private IAccountService AccountService => ServiceModule.ServiceProvider.GetService<IAccountService>();

        public void Login(LoginModel model)
        {
            AccountDTO accountDto = new AccountDTO {Login = model.Login, Password = model.Password};
            var authAcc = this.AccountService.Authenticate(accountDto);

            if (authAcc != null)
            {
                Logout();

                Provider.AuthorizedUser = new AccountDTO
                {
                    Id = authAcc.Id,
                    Login = authAcc.Login,
                    Password = authAcc.Password
                };
            }

            Home.Show();
        }

        public async Task Register(LoginModel model)
        {
            AccountDTO accountDto = new AccountDTO {Login = model.Login, Password = model.Password};
            var operationDetails = await this.AccountService.Create(accountDto);

            if (operationDetails.Succeeded)
            {
                Login(model);
            }

            Home.Show($"{operationDetails.Message}, {operationDetails.Property}");
        }

        public void Logout()
        {
            Provider.AuthorizedUser = null;
        }
    }
}
