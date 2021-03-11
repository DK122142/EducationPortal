using System.Collections.Generic;
using System.Threading.Tasks;
using EducationPortal.BLL.DTO;
using EducationPortal.Prompt.Controllers;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Models;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Prompt
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            // new Start();

            var c = SessionStorage.ServiceProvider.GetRequiredService<MaterialController>();
            await c.Add<BookModel, BookDto>(new BookModel
            {
                Name = "another one",
                PublicationYear = 1984,
                Source = "abracadabra.com",
                Authors = new List<string>()
                {
                    "first", "second", "third"
                },
                Format = "epub",
                PageCount = 12
            });
            // await c.Add<ArticleModel, ArticleDto>(new ArticleModel
            // {
            //     Name = "another new one",
            //     Published = DateTime.Now.ToString(),
            //     Source = "abracadabra.com"
            // });
        }
    }
}
