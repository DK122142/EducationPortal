using System;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Models;
using EducationPortal.Prompt.Views.Account;
using EducationPortal.Prompt.Views.Shared;

namespace EducationPortal.Prompt.Views.Material.Video
{
    public static class AddVideo
    {
        public static void Show(string msg = null)
        {
            string name;
            string link;
            string duration = "test";
            string quality = "test";
            
            Console.Clear();
            Header.Show();
            
            if (msg != null)
            {
                Console.WriteLine("========");
                Console.WriteLine($"message: {msg}");
                Console.WriteLine("========");
            }

            Console.WriteLine("(2)Add new video \n" +
                              "(3)Profile \n" +
                              "(4)Log Out. \n" +
                              "(5)Exit");

            int.TryParse(Console.ReadLine(), out var option);

            Console.Clear();

            switch (option)
            {
                case 2:
                    Console.WriteLine("Input video name: ");
                    name = Console.ReadLine();

                    Console.WriteLine("Input video link: ");
                    link = Console.ReadLine();

                    Provider.VideoController.AddVideo(new VideoModel
                    {
                        Id = Guid.NewGuid(),
                        Name = name,
                        Owner = Provider.AuthorizedUser.Id,
                        Link = link,
                        Duration = duration,
                        Quality = quality
                    });
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
