using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.Controllers;
using EducationPortal.Storage;
using EducationPortal.UI.Components;
using EducationPortal.UI.Services;

namespace EducationPortal.UI.Pages
{
    public static class Videos
    {
        public static void Show(ITableManager tm, string msg = null)
        {
            VideoController vc = new VideoController(tm);
            UserController uc = new UserController(tm);

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

            var videos = uc.GetVideos(Provider.AuthorizedUser);

            if (videos != null){

                Console.WriteLine($"Videos of {Provider.AuthorizedUser.Name}");

                foreach (var video in videos)
                {
                    Console.WriteLine($"Video: {video.Result.Name}, Link: {video.Result.Link}");
                }
            }
            
            int.TryParse(Console.ReadLine(), out var option);

            Console.Clear();

            switch (option)
            {
                case 2:
                    AddVideo.Show(tm);
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
