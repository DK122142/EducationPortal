using System;
using System.Collections.Generic;
using EducationPortal.Prompt.Controllers;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Interfaces;
using EducationPortal.Prompt.Models;
using EducationPortal.Prompt.Views.Home;
using EducationPortal.Prompt.Views.Shared.Components;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Prompt.Views.Material.Article
{
    public class AddArticle : IView
    {
        public static void View(EntityModel model = default)
        {
            
            var clickable = new List<string>
            {
                Menu.Home(Option.AddArticle),
            };

            var actions = new List<Action>
            {
                delegate { IndexPage.View(); },
            };
            
            ClickableElements.Show(clickable, actions);

            Console.Write("Article name: ");
            var name = Console.ReadLine();
            
            Console.Write("Link to article: ");
            var link = Console.ReadLine();

            Startup.ServiceProvider.GetRequiredService<ArticleController>().AddArticle(new ArticleModel()
            {
                Id = Guid.NewGuid(), 
                Name = name,
                Source = link, 
                Owner = SessionStorage.AuthorizedUser.Id,
                Published = DateTime.Now
            });
        }
    }
}
