using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProgram.Solutions
{
    public partial class Level9
    {
        public static void RepairingTheClocktower()
        {
            // Repairing the Clocktower
            Console.WriteLine("Input Number:");
            int InputNumber = Convert.ToInt32(Console.ReadLine());
            if (InputNumber % 2 == 0) { Console.WriteLine("Tick"); } // Check if InputNumber is divisible by 2 without a remainder, i.e. that it is even.
            else { Console.WriteLine("Tock"); } 
        }
    }
}
