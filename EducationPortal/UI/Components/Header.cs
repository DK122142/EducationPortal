using System;

namespace EducationPortal.UI.Components
{
    public static class Header
    {
        public static void Show(string msg = null)
        {
            if (msg != null)
            {
                Console.WriteLine("========");
                Console.WriteLine($"message: {msg}");
                Console.WriteLine("========");
            }

            Console.WriteLine("Education Portal");
            Console.WriteLine();
        }
    }
}
