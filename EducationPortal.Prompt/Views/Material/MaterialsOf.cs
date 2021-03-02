using System;
using System.Collections.Generic;
using System.Linq;
using EducationPortal.Prompt.Controllers;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Interfaces;
using EducationPortal.Prompt.Models;
using EducationPortal.Prompt.Views.Home;
using EducationPortal.Prompt.Views.Material.Article;
using EducationPortal.Prompt.Views.Shared.Components;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Prompt.Views.Material
{
    public class MaterialsOf : IView
    {
        public static void View(AccountModel model)
        {
            var materials = Startup.ServiceProvider.GetRequiredService<ArticleController>()
                .GetArticlesOf(model).Where(m => m.Owner == model.Id);

            
            var clickable = new List<string>
            {
                Menu.Home(Option.MaterialsOf(model.Login)),
                Menu.Exit,
            };

            var actions = new List<Action>
            {
                delegate { IndexPage.View(); },
                delegate { Environment.Exit(0); },
            };

            clickable.AddRange(materials.Select(m => m.Name));
            actions.AddRange(materials.Select<ArticleModel, Action>(m => delegate { ArticleView.View(m); }));
            
            ClickableElements.Show(clickable, actions);
            ClickableElements.Execute(Convert.ToInt32(Console.ReadLine()));

        }
    }
}
