using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProgram.Solutions
{
    public partial class Level13
    {
        public static void Countdown(int x)
        {
            if (x > 0)
            {
                Console.WriteLine(x);
                x--;
                Countdown(x);
            }
        }
    }
}
