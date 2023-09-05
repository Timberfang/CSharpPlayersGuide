using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProgram.Solutions
{
    public partial class Solution
    {
        public static void ConsolasAndTelim()
        {
            // Consolas and Telim
            Console.WriteLine("Bread is ready.");
            Console.WriteLine("Who is the bread for?");
            string RB = Console.ReadLine();
            Console.WriteLine("Noted: " + RB + " got bread.");
        }
    }
}
