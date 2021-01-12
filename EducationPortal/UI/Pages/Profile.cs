using System;
using EducationPortal.UI.Components;
using EducationPortal.UI.Services;

namespace EducationPortal.UI.Pages
{
    public static class Profile
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

            if (Provider.AuthorizedUser != null)
            {
                Console.WriteLine("Profile.");
                Console.WriteLine($"Welcome, {Provider.AuthorizedUser.Name}");

                Console.WriteLine("(4)Log Out. \n" +
                                  "(5)Exit");

                int.TryParse(Console.ReadLine(), out var option);

                Console.Clear();

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Wrong input!");
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

                Home.Show();
            }
        }
    }
}
