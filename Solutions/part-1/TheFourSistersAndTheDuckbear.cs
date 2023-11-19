using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProgram.Solutions
{
    public partial class Solution
    {
        public static void TheFourSistersAndTheDuckbear()
        {
            // The Four Sisters and the Duckbear
            Console.WriteLine("How many eggs were collected?");
            int Eggs = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many sisters?");
            int Sisters = Convert.ToInt32(Console.ReadLine());
            int EggsPerSister = Eggs / Sisters;
            int EggsForDuckbear = Eggs % Sisters;
            Console.WriteLine($"Each sister gets {EggsPerSister}. The duckbear gets {EggsForDuckbear}.");
            // Values where the duckbear gets more than the sisters: 1,2,3 (0 per sister).
        }
    }
}