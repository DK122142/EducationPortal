using System;
using System.Collections.Generic;
using EducationPortal.Prompt.Controllers;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Models;
using EducationPortal.Prompt.Views.Shared.Components;
using Microsoft.Extensions.DependencyInjection;
using Index = EducationPortal.Prompt.Views.Home.Index;

namespace EducationPortal.Prompt.Views.Account
{
    public static class Registration
    {
        public static async void View(EntityModel model = default(EntityModel))
        {
            var clickable = new List<string>
            {
                Menu.Home("Registration"),
            };

            var actions = new List<Action>
            {
                delegate { Index.View(); }
            };
            
            ClickableElements.Show(clickable, actions);

            Console.WriteLine("Input your login: ");
            var login = Console.ReadLine();
            
            Console.WriteLine("Input your password: ");
            var password = Console.ReadLine();
            
            await Startup.ServiceProvider.GetRequiredService<AccountController>().Register(new AccountModel
            {
                Login = login,
                Password = password
            });
        }
    }
}
