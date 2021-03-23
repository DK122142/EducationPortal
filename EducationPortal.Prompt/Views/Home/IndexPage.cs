using System;
using System.Collections.Generic;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Interfaces;
using EducationPortal.Prompt.Models;
using EducationPortal.Prompt.Views.Account;
using EducationPortal.Prompt.Views.Account.Profile;
using EducationPortal.Prompt.Views.Shared.Components;

namespace EducationPortal.Prompt.Views.Home
{
    public class IndexPage : IView
    {
        public static void View(AccountModel model = default)
        {
            var clickable = new List<string>
            {
                Menu.Home()
            };

            var actions = new List<Action>
            {
                delegate { View(); }
            };

            if (SessionStorage.AuthorizedUser == null)
            {
                clickable.AddRange(new []
                {
                    // Menu.Login,
                    Menu.Registration,
                });

                actions.AddRange(new Action[]
                {
                    // delegate { Login.View(); },
                    delegate { Registration.View(); }
                });
            }
            else
            {
                clickable.AddRange(new []
                {
                    Menu.Profile,
                    Menu.LogOut
                });

                actions.AddRange(new Action[]
                {
                    delegate { Profile.View(); },
                    delegate { SessionStorage.AuthorizedUser = null; }
                });
            }

            clickable.Add(Menu.Exit);
            actions.Add(delegate { Environment.Exit(0); });

            ClickableElements.Show(clickable, actions);
            ClickableElements.Execute(Convert.ToInt32(Console.ReadLine()));
        }
    }
}
