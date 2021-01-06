using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using EducationPortal.Controllers;
using EducationPortal.Entities;
using EducationPortal.Services;
using EducationPortal.Storage;
using EducationPortal.UI.Components;
using static System.Int32;

namespace EducationPortal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Education Portal");

            Console.WriteLine("1. Log In");
            Console.WriteLine("2. Register");

            var choice = Parse(Console.ReadLine());

            string login;
            string password;

            AuthController ac = new AuthController();

            User user;

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Log In");
                    Console.WriteLine("Input login");
                    login = Console.ReadLine();
                    Console.WriteLine("Input password");
                    password = Console.ReadLine();

                    user = ac.Login(login, password).Result;

                    if (user != null)
                    {
                        Console.WriteLine($"Logined! Name: {user.Name}");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }

                    break;
                case 2:
                    Console.WriteLine("Registration");
                    Console.WriteLine("Input login");
                    login = Console.ReadLine();
                    Console.WriteLine("Input password");
                    password = Console.ReadLine();

                    user = ac.Register(login, password).Result;

                    if (user != null)
                    {
                        Console.WriteLine($"Registered! Name: {user.Name}");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }

                    break;
                default:
                    Console.WriteLine("Wrong option");
                    break;
            }
        }
    }
}
