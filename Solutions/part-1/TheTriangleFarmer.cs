using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProgram.Solutions
{
    public partial class Solution
    {
        public static void TheTriangleFarmer()
        {
            // The Triangle Farmer
            double Base;
            double Height;
            double Area;
            Console.WriteLine("What is the base of the triangle?");
            Base = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("And the height?");
            Height = Convert.ToDouble(Console.ReadLine());
            Area = (Base * Height) / 2;
            Console.WriteLine($"The area of the triangle is {Area}.");
        }
    }
}
