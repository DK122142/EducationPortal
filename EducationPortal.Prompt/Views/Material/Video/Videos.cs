using System;
using System.Collections.Generic;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Models;
using EducationPortal.Prompt.Views.Account;
using EducationPortal.Prompt.Views.Shared;

namespace EducationPortal.Prompt.Views.Material.Video
{
    public static class Videos
    {
        public static void Show(string msg = null)
        {
            Console.Clear();
            Header.Show();
            
            if (msg != null)
            {
                Console.WriteLine("========");
                Console.WriteLine($"message: {msg}");
                Console.WriteLine("========");
            }

            Console.WriteLine("(2)Add video \n" +
                              "(3)Profile \n" +
                              "(4)Log Out. \n" +
                              "(5)Exit");

            // TODO
            IEnumerable<VideoModel> videos = null;

            if (videos != null){

                Console.WriteLine($"Videos of {Provider.AuthorizedUser.Login}");

                foreach (var video in videos)
                {
                    Console.WriteLine($"Video: {video.Name}, Link: {video.Source}");
                }
            }
            
            int.TryParse(Console.ReadLine(), out var option);

            Console.Clear();

            switch (option)
            {
                case 2:
                    AddVideo.Show();
                    break;
                case 3:
                    Profile.Show();
                    break;
                case 4:
                    Provider.AuthorizedUser = null;
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong option");
                    break;
            }

            Console.Clear();

            Home.Home.Show();
        }
    }
}
