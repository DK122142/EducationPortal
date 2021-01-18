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
    public static class Registration
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

            Console.WriteLine("Registration.");
            Console.WriteLine("(1)Registration. \n" +
                              "Already registered? (2)Log In. \n" +
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

                    Provider.AuthorizedUser = authController.Register(login, password).Result;

                    if (Provider.AuthorizedUser != null)
                    {
                        Console.Clear();

                        Home.Show(tm);
                    }
                    else
                    {
                        Home.Show(tm, $"User with name {login} already exists!");
                    }

                    break;
                case 2:
                    Login.Show(tm);
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong option");
                    break;
            }
        }
    }
}
