using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProgram.Solutions
{
    public partial class Solution // This file is used for functions used across the project - functions used in a single challenge are contained in that challenge's file.
    {
        public static string AskForString(string text)
        {
            Console.WriteLine(text);
            string output = Console.ReadLine();
            if (output != null) { return output; }
            else { return null; }
        }

        public static int AskForNumber(string text, int min = int.MinValue, int max = int.MaxValue) // Only test against minimums or maximums if specified
        {
            bool ValidChoice;
            int output;
            do
            {
                Console.Write(text);
                string choice = Console.ReadLine() ?? "No Input";
                if (!(int.TryParse(choice, out output))) // Validate input
                {
                    if (choice == "No Input") { Console.WriteLine("No input detected! Please try again"); }
                    else { Console.WriteLine($"{choice} is not a number! Please try again."); }
                }
                switch (output)
                {
                    case int n when n > max:
                        Console.WriteLine($"{output} is too high! Please try again."); // Input is over the maximum
                        ValidChoice = false;
                        break;
                    case int n when n < min:
                        Console.WriteLine($"{output} is too low! Please try again."); // Input is under the minimum
                        ValidChoice = false;
                        break;
                    default:
                        ValidChoice = true;
                        break;
                }
            }
            while (!ValidChoice); // Stop when input is valid
            return output;
        }
    }
}
