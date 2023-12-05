using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProgram.Solutions
{
    public partial class Level11
    {
        public static void ThePrototype()
        {
            // The Prototype
            string PilotChoice;
            int PilotNumber;
            string HunterGuess;
            int HunterNumber;
            bool ValidChoice = false;
            bool HunterCorrect = false;

            Console.Write("Pilot, enter a number between 0 and 100; ");
            do
            {
                PilotChoice = Console.ReadLine();
                if (!(int.TryParse(PilotChoice, out PilotNumber)))
                {
                    Console.WriteLine($"{PilotChoice} is not a number! Please try again.");
                    continue;
                }
                switch (PilotNumber)
                {
                    case int n when n > 100:
                        Console.WriteLine($"{PilotNumber} is too high! Please try again.");
                        ValidChoice = false;
                        break;
                    case int n when n < 0:
                        Console.WriteLine($"{PilotNumber} is too low! Please try again.");
                        ValidChoice = false;
                        break;
                    default:
                        ValidChoice = true;
                        Console.Clear();
                        break;

                }
            }
            while (!ValidChoice);

            Console.WriteLine("Hunter, guess the number.");
            do
            {
                Console.Write("What is your next guess? ");
                HunterGuess = Console.ReadLine();
                if (!(int.TryParse(HunterGuess, out HunterNumber)))
                {
                    Console.WriteLine($"{HunterGuess} is not a number! Please try again.");
                    continue;
                }
                switch (PilotNumber.CompareTo(HunterNumber))
                {
                    case 1:
                        Console.WriteLine($"{HunterNumber} is too low.");
                        break;
                    case -1:
                        Console.WriteLine($"{HunterNumber} is too high.");
                        break;
                    case 0:
                        Console.WriteLine($"You guessed the number!.");
                        break;
                }
            }
            while (!HunterCorrect);
        }
    }
}