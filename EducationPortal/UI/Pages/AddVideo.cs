using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.Controllers;
using EducationPortal.Entities;
using EducationPortal.Storage;
using EducationPortal.UI.Components;
using EducationPortal.UI.Services;

namespace EducationPortal.UI.Pages
{
    public static class AddVideo
    {
        public static void Show(ITableManager tm, string msg = null)
        {
            string name;
            string link;
            string duration = "test";
            string quality = "test";
            
            VideoController vc = new VideoController(tm);

            Video video;

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

                    video = vc.AddVideo(name, Provider.AuthorizedUser.Id, link, duration, quality).Result;

                    break;
                case 3:
                    Profile.Show(tm);
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

            Home.Show(tm);
        }
    }
}
