using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.AdditionalTasks.BullsAndCows
{
    public static class Service
    {
        public static List<string> GenerateCombinations()
        {
            List<string> generatedList = new List<string>();

            for (int i = 123; i <= 9876; i++) {
                int d1 = i / 1000;
                int d2 = (i / 100) % 10;
                int d3 = (i / 10) % 10;
                int d4 = i % 10;
               
                if (d1 != d2 && d1 != d3 && d1 != d4 && d2 != d3 && d2 != d4 && d3 != d4) {
                    generatedList.Add(string.Join("", i));
                }
            }
            return generatedList;
        }
    }
}
