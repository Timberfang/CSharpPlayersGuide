﻿using System;
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
            Console.Clear();

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
                string ShotAccuracy = GuessNumber(Guess, BossDistance);
                switch (ShotAccuracy)
                {
                    case "under":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("That round FELL SHORT of the target.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "over":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("That round OVERSHOT the target.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "correct":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("That round was a DIRECT HIT!");
                        Console.ForegroundColor = ConsoleColor.White;
                        ManticoreHP = (ManticoreHP - PotentialDamage);
                        break;
                    case "error":
                        Console.WriteLine("Error: Invalid input. This message should never appear, and if you see it, please pass this on to the creator of the game.");
                        break;
                }
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
            while (ManticoreHP > 0 && CityHP > 0);
        }
        public static int AskForNumberWithLimits(string text, int min, int max)
        {
            bool ValidChoice = false;
            int output;
            do
            {
                Console.WriteLine(text);
                string choice = Console.ReadLine();
                if (!(int.TryParse(choice, out output)))
                {
                    Console.WriteLine($"{choice} is not a number! Please try again.");
                }
                switch (output)
                {
                    case int n when n > max:
                        Console.WriteLine($"{output} is too high! Please try again.");
                        ValidChoice = false;
                        break;
                    case int n when n < min:
                        Console.WriteLine($"{output} is too low! Please try again.");
                        ValidChoice = false;
                        break;
                    default:
                        ValidChoice = true;
                        break;
                }
            }
            while (!ValidChoice);
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
        public static string GuessNumber(int input, int target)
        {
            string Result;
            switch (target.CompareTo(input))
            {
                case 1:
                    Result = "under";
                    return Result;
                case -1:
                    Result = "over";
                    return Result;
                case 0:
                    Result = "correct";
                    return Result;
                default:
                    Result = "error";
                    return Result;
            }
        }
    }
}
