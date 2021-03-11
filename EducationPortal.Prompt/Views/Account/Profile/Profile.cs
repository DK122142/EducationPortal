using System;
using System.Collections.Generic;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Models;
using EducationPortal.Prompt.Views.Home;
using EducationPortal.Prompt.Views.Material;
using EducationPortal.Prompt.Views.Material.Article;
using EducationPortal.Prompt.Views.Material.Book;
using EducationPortal.Prompt.Views.Material.Video;
using EducationPortal.Prompt.Views.Shared.Components;

namespace EducationPortal.Prompt.Views.Account.Profile
{
    public static class Profile
    {
        public static void View(EntityModel model = default(EntityModel))
        {
            var clickable = new List<string>
            {
                Menu.Home(Menu.Profile),
                Menu.LogOut,
                Menu.Exit,
                Option.AddArticle,
                Option.AddBook,
                Option.AddVideo,
                Option.ViewMyMaterials,
                // Option.ViewMyCourses,
                // Option.ViewAllCourses,
                // Option.ViewAllMaterials,
                // Option.AddMaterial,
                // Option.CreateNewCourse,
            };

            var actions = new List<Action>
            {
                delegate { IndexPage.View(); },
                delegate { SessionStorage.AuthorizedUser = null; },
                delegate { Environment.Exit(0); },
                delegate { AddArticle.View(); },
                delegate { AddBook.View(); },
                delegate { AddVideo.View(); },
                delegate { MaterialsOf.View(SessionStorage.AuthorizedUser); }
            };
            
            ClickableElements.Show(clickable, actions);
            ClickableElements.Execute(Convert.ToInt32(Console.ReadLine()));
        }
    }
}
