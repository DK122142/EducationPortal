using System;
using System.Collections.Generic;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Interfaces;
using EducationPortal.Prompt.Models;
using EducationPortal.Prompt.Views.Home;
using EducationPortal.Prompt.Views.Shared.Components;

namespace EducationPortal.Prompt.Views.Material.Book
{
    public class AddBook : IView
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

            Console.Write("Book name: ");
            var name = Console.ReadLine();
            
            Console.Write("Link to book: ");
            var link = Console.ReadLine();
            
            Console.Write("Pages of book: ");
            var pages = Console.ReadLine();
            
            Console.Write("Authors: ");
            var authors = Console.ReadLine();
            
            Console.Write("Format: ");
            var format = Console.ReadLine();

            // Startup.ServiceProvider.GetRequiredService<BookController>().AddBook(
            //     new BookModel
            //     {
            //         Id = string.Newstring(), 
            //         Name = name,
            //         Source = link, 
            //         OwnerId = SessionStorage.AuthorizedUser.Id,
            //         Published = DateTime.Now,
            //         PageCount = Convert.ToInt32(pages),
            //         Authors = authors.Split(",").ToList(),
            //         Format = format
            //     });
        }
    }
}
