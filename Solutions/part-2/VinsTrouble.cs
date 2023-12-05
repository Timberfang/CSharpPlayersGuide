﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProgram.Solutions
{
    public class Level19
    {
        public static void VinsTrouble() // Used for level 19
        {
            Head HeadType = Head.None; // Intialize for later use
            Fletching FletchingType = Fletching.None; // Intialize for later use

            int ShaftLength = Toolbox.AskForNumber("Please choose a length between 60 cm and 100 cm. It costs 0.05 gold per centimeter: ", 60, 100); // AskForNumber has built-in validation, so this is used instead of something here
            string ChosenHead = Toolbox.AskForString("Next, choose a Head type: Steel (10 gold), Wood (3 gold), or Obsidian (5 gold): ");
            while (HeadType == Head.None)
            {
                switch (ChosenHead.ToLower())
                {
                    case "steel":
                        HeadType = Head.Steel;
                        break;
                    case "wood":
                        HeadType = Head.Wood;
                        break;
                    case "obsidian":
                        HeadType = Head.Obsidian;
                        break;
                    default:
                        Console.WriteLine("Sorry, please choose from the options given: ");
                        break;
                }
            }

            string ChosenFletching = Toolbox.AskForString("Lastly, choose your Fletching: Plastic (10 gold), Turkey Feathers (5 gold), or Goose Feathers (3 gold): ");
            while (FletchingType == Fletching.None)
            {
                switch (ChosenFletching.ToLower())
                {
                    case "plastic":
                        FletchingType = Fletching.Plastic;
                        break;
                    case "turkey feathers":
                        FletchingType = Fletching.Turkey;
                        break;
                    case "goose feathers":
                        FletchingType = Fletching.Goose;
                        break;
                    default:
                        Console.WriteLine("Sorry, please choose from the options given: ");
                        break;
                }
            }

            Arrow ChosenArrow = new Arrow(ShaftLength,HeadType,FletchingType);
            float ChosenArrowCost = ChosenArrow.GetCost();
            Console.WriteLine($"Wonderful! Your cost for today will be {ChosenArrowCost} gold. Please come again!");
        }

        class Arrow
        {
            private int NewArrowShaft;
            private Head NewArrowHead;
            private Fletching NewArrowFletching;

            public int GetShaftLength() { return NewArrowShaft; }
            public Head GetHeadType() { return NewArrowHead; }
            public Fletching GetFletchingType() { return NewArrowFletching; }

            public float GetCost()
            {
                float cost = (float)(NewArrowShaft * 0.05);
                switch (NewArrowHead)
                {
                    case Head.Steel:
                        cost += 10;
                        break;
                    case Head.Wood:
                        cost += 3;
                        break;
                    case Head.Obsidian:
                        cost += 5;
                        break;
                }
                switch (NewArrowFletching)
                {
                    case Fletching.Plastic:
                        cost += 10;
                        break;
                    case Fletching.Turkey:
                        cost += 5;
                        break;
                    case Fletching.Goose:
                        cost += 3;
                        break;
                }
                return cost;
            }


            public Arrow(int ShaftLength, Head HeadType, Fletching FletchingType)
            {
                this.NewArrowShaft = ShaftLength;
                this.NewArrowHead = HeadType;
                this.NewArrowFletching = FletchingType;
            }
        }

        public enum Head { Steel, Wood, Obsidian, None }
        public enum Fletching { Plastic, Turkey, Goose, None }
    }
}
