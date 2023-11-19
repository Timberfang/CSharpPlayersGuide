using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LearningProgram.Solutions
{
    public partial class Solution
    {
        public static void HuntingTheManticore(int CityHP = 15, int ManticoreHP = 10)
        {
            // Start Player 1
            int BossDistance = AskForNumberWithLimits("Player 1, how far away from the city do you want to station the Manticore? ", 0, 100);
            Console.Clear(); // Hide Player 1's input from Player 2 so they need to guess

            // Start Player 2
            int RoundNumber = 1;
            Console.WriteLine("Player 2, it is your turn.");
            do
            {
                // Top Divider & Status
                Console.WriteLine("-----------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"STATUS: Round: {RoundNumber} City: {CityHP} Manticore: {ManticoreHP}");
                Console.ForegroundColor = ConsoleColor.White;

                // Calculate Damage
                int PotentialDamage = WeaponDamage(RoundNumber);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"The cannon is expected to deal {PotentialDamage} this round.");
                Console.ForegroundColor = ConsoleColor.White;

                // Fire Cannon
                int Guess = AskForNumberWithLimits("Enter desired cannon range: ", 0, 100);
                int RoundDamage = AimWeapon(Guess, BossDistance, PotentialDamage); // AimWeapon returns zero if the guess was wrong
                if (RoundDamage > 0) { ManticoreHP -= RoundDamage; } // Damage Manticore if the guess was correct
                if (ManticoreHP > 0) { CityHP--; } // Manticore attacks

                // Check for game end
                Console.ForegroundColor = ConsoleColor.Green;
                if (ManticoreHP > 0 && CityHP > 0) {
                    Console.WriteLine("The battle isn't over yet!");
                    RoundNumber++;
                } // Game Continues
                else if (ManticoreHP <= 0 && CityHP > 0) { Console.WriteLine("The Manticore is down! We won!"); } // Player 2 Wins
                else if (ManticoreHP > 0 && CityHP <= 0) { Console.WriteLine("Oh no... EVERYONE, RUN WHILE YOU CAN! THE CITY IS FALLING!"); } // Player 2 Loses
                else { Console.WriteLine("A victory, but at what cost? The Manticore is down, but our city..."); } // Both the city and the Manticore are at zero HP, and both sides lose
                Console.ForegroundColor = ConsoleColor.White;
            }
            while (ManticoreHP > 0 && CityHP > 0); // Stop if either side has zero HP remaining
        }
        public static int AskForNumberWithLimits(string text, int min, int max)
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
        public static int WeaponDamage(int Cycle)
        {
            int Damage;
            bool Fire;
            bool Electricity;

            if (Cycle % 3 == 0) { Fire = true; } // Fire activates every three cycles
            else { Fire = false; }

            if (Cycle % 5 == 0) { Electricity = true; } // Electricity activates every five cycles
            else { Electricity = false; }

            if (Fire && Electricity) { Damage = 10; } // Fire & Electricity both active - mixed output blast
            else if (!Fire && Electricity) { Damage = 3; } // Electricity active, but fire inactive - electric blast
            else if (Fire && !Electricity) { Damage = 3; } // Fire active, but electricity inactive - fire blast
            else { Damage = 1; } // Neither fire nor electricity active - normal blast

            return Damage;
        }
        public static int AimWeapon(int input, int target, int damage)
        {
            switch (target.CompareTo(input))
            {
                case 1: // Less than target
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("That round FELL SHORT of the target.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return 0;
                case -1: // Greater than target
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("That round OVERSHOT the target.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return 0;
                default: // If not less than target or greater than target, must be equal to target, thus a hit.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That round was a DIRECT HIT!");
                    Console.ForegroundColor = ConsoleColor.White;
                    return damage;
            }
        }
    }
}
