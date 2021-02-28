using System;

namespace EducationPortal.Prompt.Views.Shared
{
    public static class Component
    {
        public static string Header(string title = null)
        {
            if (title == null)
            {
                return "Education Portal";
            }

            return new string($"Education Portal{Environment.NewLine}{title}");
        }
        
        public static string LoginBtn()
        {
            return new string("Login");
        }

        public static string RegistrationBtn()
        {
            return new string("Registration");
        }

        public static string Exit()
        {
            return "Exit";
        }

        public static string Profile()
        {
            return "Profile";
        }

        public static string LogOut()
        {
            return "Log out";
        }
    }
}
