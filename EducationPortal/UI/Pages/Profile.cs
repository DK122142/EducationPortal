using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.UI.Components;
using EducationPortal.UI.Services;

namespace EducationPortal.UI.Pages
{
    public class Profile
    {
        public Profile(string msg = null)
        {
            new Header();

            if (Provider.AuthorizedUser != null)
            {
                Console.WriteLine("Profile.");
                Console.WriteLine($"Welcome, {Provider.AuthorizedUser.Name}");

                Console.WriteLine("(4)Log Out. \n" +
                                  "(5)Exit");

                var option = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (option)
                {
                    case 4:
                        Provider.AuthorizedUser = null;
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
}
