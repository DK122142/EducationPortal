using System;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Models;
using EducationPortal.Prompt.Views.Shared;

namespace EducationPortal.Prompt.Views.Home
{
    public class Login
    {
        public static void Show(string msg = null)
        {
            string login;
            string password;

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
                case 1:
                    Console.WriteLine("Input your login: ");
                    login = Console.ReadLine();

                    Console.WriteLine("Input your password: ");
                    password = Console.ReadLine();

                    SessionProvider.AccountController.Login(new AccountModel
                    {
                        Login = login,
                        Password = password
                    });

                    break;
                case 2:
                    Registration.Show();
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
