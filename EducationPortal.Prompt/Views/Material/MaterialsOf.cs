﻿using System;
using System.Collections.Generic;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Interfaces;
using EducationPortal.Prompt.Models;
using EducationPortal.Prompt.Views.Home;
using EducationPortal.Prompt.Views.Shared.Components;

namespace EducationPortal.Prompt.Views.Material
{
    public class MaterialsOf : IView
    {
        public static void View(AccountModel model)
        {
            // var articles = SessionStorage.ServiceProvider.GetRequiredService<ArticleController>()
            //     .GetArticlesOf(model).Where(m => m.OwnerId == model.Id);
            //
            // var books = Startup.ServiceProvider.GetRequiredService<BookController>()
            //     .GetBooksOf(model).Where(m => m.OwnerId == model.Id);
            //
            // var videos = Startup.ServiceProvider.GetRequiredService<VideoController>()
            //     .GetVideosOf(model).Where(m => m.OwnerId == model.Id);

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
            
            // clickable.AddRange(articles.Select(m => m.Name));
            // clickable.AddRange(videos.Select(m => m.Name));
            // clickable.AddRange(books.Select(m => m.Name));
            // actions.AddRange(articles.Select<ArticleModel, Action>(m => delegate { ArticleView.View(m); }));
            // actions.AddRange(videos.Select<VideoModel, Action>(m => delegate { VideoView.View(m); }));
            // actions.AddRange(books.Select<BookModel, Action>(m => delegate { BookView.View(m); }));
            
            ClickableElements.Show(clickable, actions);
            ClickableElements.Execute(Convert.ToInt32(Console.ReadLine()));

        }
    }
}
