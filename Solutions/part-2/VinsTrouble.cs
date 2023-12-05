using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProgram.Solutions
{
    public partial class Solution
    {
        public static void VinsTrouble() // Used for level 19
        {
            NewHead HeadType = NewHead.None; // Intialize for later use
            NewFletching FletchingType = NewFletching.None; // Intialize for later use

            int ShaftLength = AskForNumber("Please choose a length between 60 cm and 100 cm. It costs 0.05 gold per centimeter: ", 60, 100); // AskForNumber has built-in validation, so this is used instead of something here
            string ChosenHead = AskForString("Next, choose a NewHead type: Steel (10 gold), Wood (3 gold), or Obsidian (5 gold): ");
            while (HeadType == NewHead.None)
            {
                switch (ChosenHead.ToLower())
                {
                    case "steel":
                        HeadType = NewHead.Steel;
                        break;
                    case "wood":
                        HeadType = NewHead.Wood;
                        break;
                    case "obsidian":
                        HeadType = NewHead.Obsidian;
                        break;
                    default:
                        Console.WriteLine("Sorry, please choose from the options given: ");
                        break;
                }
            }

            string ChosenFletching = AskForString("Lastly, choose your NewFletching: Plastic (10 gold), Turkey Feathers (5 gold), or Goose Feathers (3 gold): ");
            while (FletchingType == NewFletching.None)
            {
                switch (ChosenFletching.ToLower())
                {
                    case "plastic":
                        FletchingType = NewFletching.Plastic;
                        break;
                    case "turkey feathers":
                        FletchingType = NewFletching.Turkey;
                        break;
                    case "goose feathers":
                        FletchingType = NewFletching.Goose;
                        break;
                    default:
                        Console.WriteLine("Sorry, please choose from the options given: ");
                        break;
                }
            }

            NewArrow ChosenArrow = new NewArrow(ShaftLength,HeadType,FletchingType);
            float ChosenArrowCost = ChosenArrow.GetCost();
            Console.WriteLine($"Wonderful! Your cost for today will be {ChosenArrowCost} gold. Please come again!");
        }

        class NewArrow
        {
            private int NewArrowShaft;
            private NewHead NewArrowHead;
            private NewFletching NewArrowFletching;

            public int GetShaftLength() { return NewArrowShaft; }
            public NewHead GetHeadType() { return NewArrowHead; }
            public NewFletching GetFletchingType() { return NewArrowFletching; }

            public float GetCost()
            {
                float cost = (float)(NewArrowShaft * 0.05);
                switch (NewArrowHead)
                {
                    case NewHead.Steel:
                        cost += 10;
                        break;
                    case NewHead.Wood:
                        cost += 3;
                        break;
                    case NewHead.Obsidian:
                        cost += 5;
                        break;
                }
                switch (NewArrowFletching)
                {
                    case NewFletching.Plastic:
                        cost += 10;
                        break;
                    case NewFletching.Turkey:
                        cost += 5;
                        break;
                    case NewFletching.Goose:
                        cost += 3;
                        break;
                }
                return cost;
            }


            public NewArrow(int ShaftLength, NewHead HeadType, NewFletching FletchingType)
            {
                this.NewArrowShaft = ShaftLength;
                this.NewArrowHead = HeadType;
                this.NewArrowFletching = FletchingType;
            }
        }
    }

    public enum NewHead { Steel, Wood, Obsidian, None }
    public enum NewFletching { Plastic, Turkey, Goose, None }
}
