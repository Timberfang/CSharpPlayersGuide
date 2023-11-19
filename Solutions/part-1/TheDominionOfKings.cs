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
        public static void TheDominionOfKings()
        {
            // The Dominion of Kings
            Console.WriteLine("For you, how many estates do you have?");
            int Estates = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Now, how many duchies?");
            int Duchies = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("And provinces?");
            int Provinces = Convert.ToInt32(Console.ReadLine());
            int Total = Estates + (Duchies * 3) + (Provinces * 6);
            Console.WriteLine($"With {Estates} estates, {Duchies} duchies, and {Provinces} provinces, you have a total of {Total} points.");
        }
    }
}