using System;
using System.Collections.Generic;
using System.Text;
using EducationPortal.Prompt.Controllers;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Interfaces;
using EducationPortal.Prompt.Models;
using EducationPortal.Prompt.Views.Home;
using EducationPortal.Prompt.Views.Shared.Components;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Prompt.Views.Material.Article
{
    public class ArticleView : IView
    {
        public static void View(ArticleModel model)
        {
            var clickable = new List<string>
            {
                Menu.Home(model.Name),
                Menu.Exit,
            };

            var actions = new List<Action>
            {
                delegate { IndexPage.View(); },
                delegate { Environment.Exit(0); },
            };

            var article = SessionStorage.ServiceProvider.GetRequiredService<ArticleController>().GetById(model.Id);
            var strBuild = new StringBuilder();

            strBuild.AppendLine($"Name: {article.Name}");
            // strBuild.AppendLine($"Article of: {article.OwnerId}");
            strBuild.AppendLine($"Link: {article.Source}");
            strBuild.AppendLine($"PublicationYear: {article.Published}");

            ClickableElements.Show(clickable, actions);

            Console.WriteLine(strBuild.ToString());

            ClickableElements.Execute(Convert.ToInt32(Console.ReadLine()));
        }
    }
}
