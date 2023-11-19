using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProgram.Solutions
{
    public partial class Solution
    {
        public static void TheMagicCannon()
        {
            // The Magic Cannon
            int Cycle = 1;
            bool Fire;
            bool Electricity;
            while (Cycle <= 100)
            {
                if (Cycle % 3 == 0) { Fire = true; } // Fire activates every three cycles
                else { Fire = false; }

                if (Cycle % 5 == 0) { Electricity = true; } // Electricity activates every five cycles
                else { Electricity = false; }

                if (Fire && Electricity) // Fire & Electricity both active - mixed output blast
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{Cycle}: Mixed!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (!Fire && Electricity){ // Electricity active, but fire inactive - electric blast
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{Cycle}: Electricity");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (Fire && !Electricity) // Fire active, but electricity inactive - fire blast
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{Cycle}: Fire");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else { Console.WriteLine($"{Cycle}: Normal"); } // Neither fire nor electricity active - normal blast

                Cycle++; // Increment cycle
            }
        }
    }
}