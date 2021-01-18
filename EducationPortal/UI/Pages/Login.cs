using System;
using EducationPortal.Controllers;
using EducationPortal.Storage;
using EducationPortal.UI.Components;
using EducationPortal.UI.Services;

namespace EducationPortal.UI.Pages
{
    public class Login
    {
        public static void Show(ITableManager tm, string msg = null)
        {
            string login;
            string password;
            AuthController authController = new AuthController(tm);

            Console.Clear();
            Header.Show();
            
            if (msg != null)
            {
                Console.WriteLine("========");
                Console.WriteLine($"message: {msg}");
                Console.WriteLine("========");
            }

            Console.WriteLine("Login.");
            Console.WriteLine("(1)Log In. \n" +
                              "Not registered yet? (2)Registration. \n" +
                              "(5)Exit");
            
            int.TryParse(Console.ReadLine(), out var option);

            Console.Clear();

            switch (option)
            {
                case 0:
                    Console.WriteLine("Wrong input!");
                    break;
                case 1:
                    Console.WriteLine("Input your login: ");
                    login = Console.ReadLine();

                    Console.WriteLine("Input your password: ");
                    password = Console.ReadLine();

                    Provider.AuthorizedUser = authController.Login(login, password).Result;
                    break;
                case 2:
                    Registration.Show(tm);
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
