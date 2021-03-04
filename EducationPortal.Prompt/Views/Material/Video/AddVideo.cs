using System;
using System.Collections.Generic;
using EducationPortal.Prompt.Controllers;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Interfaces;
using EducationPortal.Prompt.Models;
using EducationPortal.Prompt.Views.Home;
using EducationPortal.Prompt.Views.Shared.Components;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Prompt.Views.Material.Video
{
    public class AddVideo : IView
    {
        public static void View(EntityModel model = default)
        {
            var clickable = new List<string>
            {
                Menu.Home(Option.AddVideo),
            };

            var actions = new List<Action>
            {
                delegate { IndexPage.View(); },
            };
            
            ClickableElements.Show(clickable, actions);

            Console.Write("Input video name: ");
            var name = Console.ReadLine();
            
            Console.Write("Input video link: ");
            var link = Console.ReadLine();

            Console.Write("Input video duration: ");
            var duration = Console.ReadLine();

            Console.Write("Input video quality: ");
            var quality = Console.ReadLine();
                  
            Startup.ServiceProvider.GetRequiredService<VideoController>().AddVideo(
                new VideoModel
                {
                    Id = Guid.NewGuid(),
                    Duration = duration,
                    Name = name,
                    Owner = SessionStorage.AuthorizedUser.Id,
                    Quality = quality,
                    Source = link
                });
        }
    }
}
