using System;
using System.Collections.Generic;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Models;
using EducationPortal.Prompt.Views.Account;
using EducationPortal.Prompt.Views.Shared;

namespace EducationPortal.Prompt.Views.Home
{
    public static class Index
    {
        public static void View(EntityModel model = default(EntityModel))
        {
            var clickable = new List<string>
            {
                Component.Header()
            };

            var actions = new List<Action>()
            {
                delegate { Index.View(); }
            };

            if (SessionStorage.AuthorizedUser == null)
            {
                clickable.AddRange(new []
                {
                    Component.LoginBtn(),
                    Component.RegistrationBtn(),
                });

                actions.AddRange(new Action[]
                {
                    delegate { Login.View(); },
                    delegate { Registration.View(); }
                });
            }
            else
            {
                clickable.AddRange(new []
                {
                    Component.Profile(),
                    Component.LogOut()
                });

                actions.AddRange(new Action[]
                {
                    delegate { Profile.View(); },
                    delegate { SessionStorage.AuthorizedUser = null; }
                });
            }

            clickable.Add(Component.Exit());
            actions.Add(delegate { Environment.Exit(0); });

            ClickableElements.Show(clickable, actions);
            ClickableElements.Execute(Convert.ToInt32(Console.ReadLine()));

            // ClickableElements.Show(new[]
            // {
            //     Component.Header(),
            //     Component.LoginBtn(),
            //     Component.RegistrationBtn(),
            //     Component.Exit()
            // }, new Action[]
            // {
            //     delegate { Index.View<TModel>(); },
            //     delegate { Login.View<TModel>(); },
            //     delegate { Registration.View<TModel>(); },
            //     delegate { Environment.Exit(0); }
            // });


            // Component.Header();
            //
            //
            //
            // if (SessionStorage.AuthorizedUser == null)
            // {
            //     Login.View();
            // }
            // else
            // {
            //     Profile.View();
            // }
        }
    }
}
