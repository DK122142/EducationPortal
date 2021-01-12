using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.UI.Components;
using EducationPortal.UI.Services;

namespace EducationPortal.UI.Pages
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
