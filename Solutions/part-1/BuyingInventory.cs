using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProgram.Solutions
{
    public partial class Solution
    {
        public static void BuyingInventory()
        {
            // Buying Inventory
            int RopePrice = 10;
            int TorchPrice = 16;
            int ClimbingPrice = 24;
            int WaterPrice = 2;
            int MachetePrice = 20;
            int CanoePrice = 200;
            int FoodPrice = 2;

            // Discount if it's my name.
            Console.Write("Before I forget, what's your name? ");
            string Name = Console.ReadLine();
            if (Name == "Lycaon")
            {
                RopePrice /= 2;
                TorchPrice /= 2;
                ClimbingPrice /= 2;
                WaterPrice /= 2;
                MachetePrice /= 2;
                CanoePrice /= 2;
                FoodPrice /= 2;
            }

            Console.Write(
                @"The following items are available:
                1 – Rope
                2 – Torches
                3 – Climbing Equipment
                4 – Clean Water
                5 – Machete
                6 – Canoe
                7 – Food Supplies
                What number do you want to see the price of? "
            );
            int Choice = Convert.ToInt32(Console.ReadLine());
            string Response = Choice switch
            {
                1 => $"Rope costs {RopePrice} gold.",
                2 => $"Torches cost {TorchPrice} gold.",
                3 => $"Climbing Equipment costs {ClimbingPrice} gold.",
                4 => $"Clean Water costs {WaterPrice} gold.",
                5 => $"Machetes cost {MachetePrice} gold each.",
                6 => $"A canoe costs {CanoePrice} gold.",
                7 => $"Food supplies costs {FoodPrice} gold.",
                _ => "Sorry, I didn't quite catch that. Can you pick something from the list?"
            };
            Console.WriteLine( Response );
        }
    }
}
