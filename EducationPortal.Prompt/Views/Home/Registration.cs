using System;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Models;
using EducationPortal.Prompt.Views.Shared;

namespace EducationPortal.Prompt.Views.Home
{
    public static class Registration
    {
        public static async void Show(string msg = null)
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

            Console.WriteLine("Registration.");
            Console.WriteLine("(1)Registration. \n" +
                              "Already registered? (2)Log In. \n" +
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

                    await SessionProvider.AccountController.Register(new AccountModel
                    {
                        Login = login,
                        Password = password
                    });

                    if (SessionProvider.AuthorizedUser != null)
                    {
                        Console.Clear();
                        Home.Show();
                    }
                    else
                    {
                        Home.Show($"User with login {login} already exists!");
                    }

                    break;
                case 2:
                    Login.Show();
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
