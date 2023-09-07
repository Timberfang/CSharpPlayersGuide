using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProgram.Solutions
{
    public partial class Solution
    {
        public static void TheDefenseOfConsolas()
        {
            // The Defense of Consolas
            Console.Title = "Defense of Consolas";
            Console.Write("The target row? ");
            int Row = Convert.ToInt32(Console.ReadLine());
            Console.Write("Quickly now, what's the target column? ");
            int Column = Convert.ToInt32(Console.ReadLine());
            Console.Write("Gather together! We must deploy as follows:\n");
            Console.Write($"First, to ({Row - 1}, {Column}),\n");
            Console.Write($"Next, to ({Row + 1}, {Column}),\n");
            Console.Write($"You there, to ({Row}, {Column - 1}),\n");
            Console.Write($"Finally, you go to ({Row}, {Column + 1})!\n");
            Console.Beep();
        }
    }
}