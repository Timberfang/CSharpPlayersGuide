﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningProgram.Solutions;

namespace LearningProgram.Solutions
{
    public class Level17
    {
        public static void SimulasSoup()
        {
            string UserChoice;
            FoodType FoodChoice = FoodType.None;                    // Initilialize for later use
            MainIngredient IngredientChoice = MainIngredient.None;  // Initilialize for later use
            Seasoning SeasoningChoice = Seasoning.None;             // Initilialize for later use

            Console.WriteLine("MENU");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Note: Please state only the menu item needed - no other text!");

            Console.WriteLine("Food Type - Choose One!");
            while (FoodChoice == FoodType.None)
            {
                UserChoice = Toolbox.AskForString($"{FoodType.Soup}, {FoodType.Stew}, or {FoodType.Gumbo}");

                switch (UserChoice.ToLower())
                {
                    case "soup":
                        FoodChoice = FoodType.Soup;
                        break;
                    case "stew":
                        FoodChoice = FoodType.Stew;
                        break;
                    case "gumbo":
                        FoodChoice = FoodType.Gumbo;
                        break;
                    default:
                        Console.WriteLine("Sorry, please choose from the options given: ");
                        break;
                }
            }

            Console.WriteLine("Main Ingredient - Choose One!");
            while (IngredientChoice == MainIngredient.None)
            {
                UserChoice = Toolbox.AskForString($"{MainIngredient.Mushrooms}, {MainIngredient.Chicken}, {MainIngredient.Carrots} or {MainIngredient.Potatoes}");

                switch (UserChoice.ToLower())
                {
                    case "mushrooms":
                        IngredientChoice = MainIngredient.Mushrooms;
                        break;
                    case "chicken":
                        IngredientChoice = MainIngredient.Chicken;
                        break;
                    case "carrots":
                        IngredientChoice = MainIngredient.Carrots;
                        break;
                    case "potatoes":
                        IngredientChoice = MainIngredient.Potatoes;
                        break;
                    default:
                        Console.WriteLine("Sorry, please choose from the options given: ");
                        break;
                }
            }

            Console.WriteLine("Seasoning - Choose One!");
            while (SeasoningChoice == Seasoning.None)
            {
                UserChoice = Toolbox.AskForString($"{Seasoning.Spicy}, {Seasoning.Salty}, or {Seasoning.Sweet}");

                if (!String.IsNullOrEmpty(UserChoice))
                {
                    switch (UserChoice.ToLower())
                    {
                        case "spicy":
                            SeasoningChoice = Seasoning.Spicy;
                            break;
                        case "salty":
                            SeasoningChoice = Seasoning.Salty;
                            break;
                        case "sweet":
                            SeasoningChoice = Seasoning.Sweet;
                            break;
                        default:
                            Console.WriteLine("Sorry, please choose from the options given: ");
                            break;
                    }
                }
                else { Console.WriteLine("No input detected. Please try again!"); }
            }

            (FoodType Type, MainIngredient Ingredient, Seasoning Seasoning) PreparedFood = (FoodChoice, IngredientChoice, SeasoningChoice);
            Console.WriteLine($"Your choice: {PreparedFood.Seasoning} {PreparedFood.Ingredient} {PreparedFood.Type}");
        }
    }
}

enum FoodType { Soup, Stew, Gumbo, None }
enum MainIngredient { Mushrooms, Chicken, Carrots, Potatoes, None }
enum Seasoning { Spicy, Salty, Sweet, None }