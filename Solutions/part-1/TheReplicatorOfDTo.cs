using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProgram.Solutions
{
    public partial class Solution
    {
        public static void TheReplicatorOfDTo()
        {
            // The Replicator of D'To
            int[] Array = new int[5];
            int[] ArrayCopy = Array;

            for (int Index = 0; Index < 5; Index++)
            {
                Console.Write($"Enter a number for array slot {Index}: ");
                Array[Index] = Convert.ToInt32(Console.ReadLine());
            }

            for (int Index = 0; Index < 5; Index++)
            {
                Console.WriteLine($"Array value at {Index}: {Array[Index]} - Copied to copy array.");
                ArrayCopy[Index] = Array[Index];
            }

            for (int Index = 0; Index < 5; Index++)
            {
                Console.WriteLine($"Copy Array value at {Index}: {ArrayCopy[Index]}.");
            }
        }
    }
}