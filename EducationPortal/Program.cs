using System;
using EducationPortal.AdditionalTasks.BullsAndCows;
using EducationPortal.AdditionalTasks.CSVGenerator;

namespace EducationPortal
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("1. Bulls and Cows");
            Console.WriteLine("2. CSV generator");

            var option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    BullsCows.Start();
                    break;
                case 2:
                    CSVGenerator.Start();
                    break;
                default:
                    Console.WriteLine("Wrong option");
                    break;
            }
        }
    }
}
