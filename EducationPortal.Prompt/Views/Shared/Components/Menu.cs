using System;
using EducationPortal.Prompt.Infrastructure;

namespace EducationPortal.Prompt.Views.Shared.Components
{
    public static class Menu
    {
        public static string Home(string title = null)
        {
            if (title == null)
            {
                return "Education Portal";
            }

            return new string($"Education Portal{Environment.NewLine}{title}");
        }
        
        public static string Login()
        {
            return new string("Login");
        }

        public static string Registration()
        {
            return new string("Registration");
        }

        public static string Exit()
        {
            return "Exit";
        }

        public static string Profile()
        {
            return $"{SessionStorage.AuthorizedUser.Login} (Profile)";
        }

        public static string LogOut()
        {
            return "Log out";
        }
    }
}
