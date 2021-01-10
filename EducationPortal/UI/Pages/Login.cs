using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.Controllers;
using EducationPortal.UI.Components;
using EducationPortal.UI.Services;

namespace EducationPortal.UI.Pages
{
    public class Login
    {
        public Login(string msg = null)
        {
            string login;
            string password;
            AuthController authController = new AuthController();

            Console.Clear();
            new Header();
            
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
                    new Registration();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong option");
                    break;
            }

            Console.Clear();

            new Home();
        }
        
    }
}
