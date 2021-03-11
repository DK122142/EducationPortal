using System;
using System.Collections.Generic;
using System.Text;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Interfaces;
using EducationPortal.Prompt.Models;
using EducationPortal.Prompt.Views.Home;
using EducationPortal.Prompt.Views.Shared.Components;

namespace EducationPortal.Prompt.Views.Material.Video
{
    public class VideoView : IView
    {
        public static void View(VideoModel model)
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

            // var video = Startup.ServiceProvider.GetRequiredService<VideoController>().GetById(model.Id);
            var strBuild = new StringBuilder();

            // strBuild.AppendLine($"Name: {video.Name}");
            // strBuild.AppendLine($"Type: {video.MaterialType}");
            // strBuild.AppendLine($"Video of: {video.OwnerId}");
            // strBuild.AppendLine($"Link: {video.Source}");

            ClickableElements.Show(clickable, actions);

            Console.WriteLine(strBuild.ToString());

            ClickableElements.Execute(Convert.ToInt32(Console.ReadLine()));
        }
    }
}
