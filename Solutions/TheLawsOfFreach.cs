using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LearningProgram.Solutions
{
    public partial class Solution
    {
        public static void TheLawsOfFreach()
        {
            // The Laws of Freach
            int[] SmallestArray = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };
            int currentSmallest = int.MaxValue; // Start higher than anything in the array.
            foreach (int Integer in SmallestArray)
            {
                if (Integer < currentSmallest)
                    currentSmallest = Integer;
            }
            Console.WriteLine(currentSmallest);

            int[] AverageArray = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };
            int total = 0;
            foreach (int Integer in AverageArray)
                total += Integer;
            float average = (float)total / AverageArray.Length;
            Console.WriteLine(average);
        }
    }
}