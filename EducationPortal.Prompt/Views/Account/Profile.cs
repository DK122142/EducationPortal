using System;
using System.Collections.Generic;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Models;
using EducationPortal.Prompt.Views.Home;
using EducationPortal.Prompt.Views.Shared.Components;

namespace EducationPortal.Prompt.Views.Account
{
    public static class Profile
    {
        public static void View(EntityModel model = default(EntityModel))
        {
            var clickable = new List<string>
            {
                Menu.Home(Menu.Profile()),
                Menu.LogOut(),
                Menu.Exit(),
                // Option.AddMaterial(),
                // Option.CreateNewCourse(),
                // Option.ViewAllCourses(),
            };

            var actions = new List<Action>
            {
                delegate { IndexPage.View(); },
                delegate { SessionStorage.AuthorizedUser = null; },
                delegate { Environment.Exit(0); }
            };
            
            ClickableElements.Show(clickable, actions);
            ClickableElements.Execute(Convert.ToInt32(Console.ReadLine()));
        }
    }
}
