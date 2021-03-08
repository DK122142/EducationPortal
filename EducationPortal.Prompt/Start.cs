using System;
using EducationPortal.Prompt.Controllers;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Models;
using EducationPortal.Prompt.Views.Home;
using EducationPortal.Prompt.Views.Material.Article;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Prompt
{
    public class Start
    {
        public Start()
        {
            while (true)
            {
                IndexPage.View();
            }
        }
    }
}
