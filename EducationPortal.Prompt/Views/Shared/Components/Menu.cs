using System;
using EducationPortal.Prompt.Infrastructure;

namespace EducationPortal.Prompt.Views.Shared.Components
{
    public static class Menu
    {
        public static string Home(string title = null) =>
            title == null ? "Education Portal" : $"Education Portal{Environment.NewLine}{title}";

        public static string Login => "Log In";

        public static string Registration => "Registration";

        public static string Exit => "Exit";

        public static string Profile => $"{SessionStorage.AuthorizedUser.UserName} (Profile)";

        public static string LogOut => "Log out";
    }
}
