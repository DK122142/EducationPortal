using System;
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
            await c.Add<ArticleModel, ArticleDto>(new ArticleModel
            {
                Name = "another one",
                Published = DateTime.Now.ToString(),
                Source = "link.com"
            });
        }
    }
}
