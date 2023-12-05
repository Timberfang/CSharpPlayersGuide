using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProgram.Solutions
{
    public class Toolbox // This file is used for functions used across the project - functions used in a single challenge are contained in that challenge's file.
    {
        public static string AskForString(string text, bool warn = true, string warning = "No input detected. Please try again!")
        {
            bool ValidOutput = false;
            while (true)
            {
                Console.Write(text);
                string output = Console.ReadLine();
                if (!String.IsNullOrEmpty(output)) // input was given, so return the input
                {
                    return output;
                }
                else if (warn) // no input given and warn was set to true, so repeat the loop until input is given
                {
                    Console.WriteLine(warning);
                }
                else // no input given, but warn was set to false, so this is accepted
                {
                    return null;
                }
            }
        }

        public static int AskForNumber(string text, int min = int.MinValue, int max = int.MaxValue) // Only test against minimums or maximums if specified
        {
            bool ValidChoice;
            int output;
            do
            {
                Console.Write(text);
                string choice = Console.ReadLine();
                if (!(int.TryParse(choice, out output))) // Validate input
                {
                    if (string.IsNullOrEmpty(choice)) { Console.WriteLine("No input detected! Please try again"); }
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
