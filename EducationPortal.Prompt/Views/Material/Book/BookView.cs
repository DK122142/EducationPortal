using System;
using System.Collections.Generic;
using System.Text;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Interfaces;
using EducationPortal.Prompt.Models;
using EducationPortal.Prompt.Views.Home;
using EducationPortal.Prompt.Views.Shared.Components;

namespace EducationPortal.Prompt.Views.Material.Book
{
    public class BookView : IView
    {
        public static void View(BookModel model)
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

            // var book = Startup.ServiceProvider.GetRequiredService<BookController>().GetById(model.Id);
            var strBuild = new StringBuilder();

            // strBuild.AppendLine($"Name: {book.Name}");
            // strBuild.AppendLine($"Type: {book.MaterialType}");
            // strBuild.AppendLine($"Book of: {book.OwnerId}");
            // strBuild.AppendLine($"Link: {book.Source}");
            // strBuild.AppendLine($"Pages: {book.PageCount}");
            // strBuild.AppendLine($"Authors: {string.Join(",", book.Authors)}");
            // strBuild.AppendLine($"Format: {book.Format}");

            ClickableElements.Show(clickable, actions);

            Console.WriteLine(strBuild.ToString());

            ClickableElements.Execute(Convert.ToInt32(Console.ReadLine()));
        }
    }
}
