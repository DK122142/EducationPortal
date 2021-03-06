using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationPortal.Prompt.Controllers;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Interfaces;
using EducationPortal.Prompt.Models;
using EducationPortal.Prompt.Views.Home;
using EducationPortal.Prompt.Views.Shared.Components;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Prompt.Views.Account
{
    public class Login : IView
    {
        public static async Task View(EntityModel model = default)
        {
            var clickable = new List<string>
            {
                Menu.Home(Menu.Login),
            };

            var actions = new List<Action>
            {
                delegate { IndexPage.View(); }
            };
            
            ClickableElements.Show(clickable, actions);

            Console.Write("Input your login: ");
            var login = Console.ReadLine();
            
            Console.Write("Input your password: ");
            var password = Console.ReadLine();

            await SessionStorage.ServiceProvider.GetRequiredService<AccountController>().Login(new AccountModel
            {
                UserName = login,
                Password = password
            });
        }
    }
}
