using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProgram.Solutions
{
    public class Level21
    {
        public static void ArrowFactories()
        {
            ArrowType ArrowFormat = ArrowType.None; // Intialize for later use
            Arrow ArrowPurchase = new Arrow();

            while (ArrowFormat == ArrowType.None)
            {
                Console.WriteLine("Please choose an arrow type: The Elite Arrow (24.75g), Beginner Arrow (9.75g), Marksman Arrow (16.25g), or a Custom Arrow (varies by selection).");
                string ChosenArrow = Toolbox.AskForString(@"Enter ""Elite"", ""Beginner"", ""Marksman"", or ""Custom"": ");

                switch (ChosenArrow.ToLower())
                {
                    case "elite":
                        ArrowFormat = ArrowType.Elite;
                        break;
                    case "beginner":
                        ArrowFormat = ArrowType.Beginner;
                        break;
                    case "marksman":
                        ArrowFormat = ArrowType.Marksman;
                        break;
                    case "custom":
                        ArrowFormat = ArrowType.Custom;
                        break;
                    default:
                        Console.WriteLine("Sorry, please choose from the options given: ");
                        break;
                }
            }

            switch (ArrowFormat)
            {
                case ArrowType.Elite:
                    ArrowPurchase = Arrow.CreateEliteArrow();
                    break;
                case ArrowType.Beginner:
                    ArrowPurchase = Arrow.CreateBeginnerArrow();
                    break;
                case ArrowType.Marksman:
                    ArrowPurchase = Arrow.CreateMarksmanArrow();
                    break;
                case ArrowType.Custom:
                    ArrowPurchase = CustomArrow();
                    break;
            }

            float ArrowPurchaseCost = ArrowPurchase.GetCost();
            Console.WriteLine($"Wonderful! Your cost for today will be {ArrowPurchaseCost} gold. Please come again!");
        }

        public static Arrow CustomArrow()
        {
            Head HeadType = Head.None; // Intialize for later use
            Fletching FletchingType = Fletching.None; // Intialize for later use

            int ShaftLength = Toolbox.AskForNumber("Please choose a length between 60 cm and 100 cm. It costs 0.05 gold per centimeter: ", 60, 100); // AskForNumber has built-in validation, so this is used instead of something here
            while (HeadType == Head.None)
            {
                string ChosenHead = Toolbox.AskForString("Next, choose a Head type: Steel (10 gold), Wood (3 gold), or Obsidian (5 gold): ");

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

            while (FletchingType == Fletching.None)
            {
                string ChosenFletching = Toolbox.AskForString("Lastly, choose your Fletching: Plastic (10 gold), Turkey Feathers (5 gold), or Goose Feathers (3 gold): ");

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

            Arrow ChosenArrow = new Arrow(ShaftLength, HeadType, FletchingType);
            return ChosenArrow;
        }

        public class Arrow
        {
            public int ArrowShaft { get; }
            public Head Arrowhead { get; }
            public Fletching ArrowFletching { get; }

            public Arrow()
            {
                ArrowShaft = 60;
                Arrowhead = Head.None;
                ArrowFletching = Fletching.None;
            }

            public float GetCost()
            {
                float cost = (float)(ArrowShaft * 0.05);
                switch (Arrowhead)
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
                switch (ArrowFletching)
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

            public static Arrow CreateEliteArrow()
            {
                return new Arrow(95, Head.Steel, Fletching.Plastic);
            }
            public static Arrow CreateBeginnerArrow()
            {
                return new Arrow(75, Head.Wood, Fletching.Goose);
            }
            public static Arrow CreateMarksmanArrow()
            {
                return new Arrow(65, Head.Steel, Fletching.Goose);
            }

            public Arrow(int ShaftLength, Head HeadType, Fletching FletchingType)
            {
                this.ArrowShaft = ShaftLength;
                this.Arrowhead = HeadType;
                this.ArrowFletching = FletchingType;
            }
        }

        public enum Head { Steel, Wood, Obsidian, None }
        public enum Fletching { Plastic, Turkey, Goose, None }
        public enum ArrowType { Elite, Beginner, Marksman, Custom, None}
    }
}
