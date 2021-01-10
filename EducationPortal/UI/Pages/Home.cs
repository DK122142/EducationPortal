using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.UI.Components;
using EducationPortal.UI.Services;

namespace EducationPortal.UI.Pages
{
    public class Home
    {
        public Home(string msg = null)
        {
            Console.Clear();
            new Header();
            
            if (msg != null)
            {
                Console.WriteLine("========");
                Console.WriteLine($"message: {msg}");
                Console.WriteLine("========");
            }

            if (Provider.AuthorizedUser == null)
            {
                new Login(msg);
            }
            else
            {
                new Profile(msg);
            }
        }
    }
}
