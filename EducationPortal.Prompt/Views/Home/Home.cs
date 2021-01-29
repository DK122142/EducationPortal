using System;
using EducationPortal.Prompt.Infrastructure;
using EducationPortal.Prompt.Views.Account;
using EducationPortal.Prompt.Views.Shared;

namespace EducationPortal.Prompt.Views.Home
{
    public static class Home
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
            
            if (Provider.AuthorizedUser == null)
            {
                Login.Show(msg);
            }
            else
            {
                Profile.Show(msg);
            }
        }
    }
}
