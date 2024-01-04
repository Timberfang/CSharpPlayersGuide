namespace LearningProgram.Solutions
{
    public class Level24
    {
        public static void ThePoint()
        {
            Point FirstPoint = new Point(2, 3);
            Point SecondPoint = new Point(-4, 0);
            Console.WriteLine($"First point: ({FirstPoint.XCoord}, {FirstPoint.YCoord}). Second point: ({SecondPoint.XCoord}, {SecondPoint.YCoord}).");
        }
        public static void TheColor()
        {
            Color FirstColor = new Color(0, 255, 0);
            Color SecondColor = Color.Purple;
            Console.WriteLine($"First color: Green (r{FirstColor.RedChannel}, g{FirstColor.GreenChannel}, b{FirstColor.BlueChannel}.");
            Console.WriteLine($"Second Color: Purple (r{SecondColor.RedChannel}, g{SecondColor.GreenChannel}, b{SecondColor.BlueChannel}).");
        }

        public static void TheCard()
        {
            foreach (CardColor Color in Enum.GetValues(typeof(CardColor)))
            {
                foreach (CardRank Rank in Enum.GetValues(typeof(CardRank)))
                {
                    Card CurrentCard = new Card(Color, Rank);
                    Console.WriteLine($"Created Card: The {CurrentCard.Color} {CurrentCard.Rank}");
                }
            }
        }

        class Point
        {
            public int XCoord { get; }
            public int YCoord { get; }

            public Point(int X, int Y)
            {
                this.XCoord = X;
                this.YCoord = Y;
            }
            public Point()
            {
                this.XCoord = 0;
                this.YCoord = 0;
            }
        }

        class Color
        {
            public byte RedChannel { get; set; }
            public byte GreenChannel { get; set; }
            public byte BlueChannel { get; set; }

            public static Color White { get; } = new Color(255, 255, 255);
            public static Color Black { get; } = new Color(0, 0, 0);
            public static Color Red { get; } = new Color(255, 0, 0);
            public static Color Orange { get; } = new Color(255, 165, 0);
            public static Color Green { get; } = new Color(0, 128, 0); // The book directed 128 here, rather than 256.
            public static Color Blue { get; } = new Color(0, 0, 255);
            public static Color Purple { get; } = new Color(128, 0, 128);

            public Color(byte RedChannel, byte GreenChannel, byte BlueChannel)
            {
                this.RedChannel = RedChannel;
                this.GreenChannel = GreenChannel;
                this.BlueChannel = BlueChannel;
            }
        }

        class Card
        {
            public CardColor Color { get; }
            public CardRank Rank { get; }

            public Card(CardColor Color, CardRank Rank)
            {
                this.Color = Color;
                this.Rank = Rank;
            }

            public bool SymbolCard
            {
                get
                {
                    return this.Rank == CardRank.Dollar || this.Rank == CardRank.Percent || this.Rank == CardRank.Carrot || this.Rank == CardRank.Ampersand;
                }
            }
        }

        public class Door
        {
            private DoorStatus CurrentState { get; set; }
            private int Passcode { get; set; }


            public Door(int Passcode)
            {
                this.CurrentState = DoorStatus.Locked;
                this.Passcode = Passcode;
            }

            public DoorStatus GetState()
            {
                return this.CurrentState;
            }
            public void ChangePasscode(int CurrentCode, int NewCode)
            {
                if (this.Passcode == CurrentCode)
                {
                    this.Passcode = NewCode;
                    Console.WriteLine("Passcode changed.");
                }
                else
                {
                    Console.WriteLine("Error: Input for current passcode does not match stored code!");
                }
            }

            public void UnlockDoor(int Passcode)
            {
                if (this.Passcode == Passcode)
                {
                    this.CurrentState = DoorStatus.Closed;
                    Console.WriteLine("Door unlocked");
                }
                else
                {
                    Console.WriteLine("Error: Input for current passcode does not match stored code!");
                }
            }
            public void LockDoor()
            {
                switch (this.CurrentState)
                {
                    case DoorStatus.Closed:
                        this.CurrentState = DoorStatus.Locked;
                        Console.WriteLine("Door locked");
                        break;
                    case DoorStatus.Locked:
                        Console.WriteLine("Error: The door is already locked!");
                        break;
                    case DoorStatus.Open:
                        Console.WriteLine("Error: The door is still open! Please close it first.");
                        break;
                    default:
                        Console.WriteLine("Error: Something weird is going on. If you see this, please contact the developer.");
                        break;
                }
            }
            public void OpenDoor()
            {
                switch (this.CurrentState)
                {
                    case DoorStatus.Closed:
                        this.CurrentState = DoorStatus.Open;
                        Console.WriteLine("Door opened.");
                        break;
                    case DoorStatus.Open:
                        Console.WriteLine("Error: The door is already open");
                        break;
                    case DoorStatus.Locked:
                        Console.WriteLine("Error: The door is locked! Please open it first.");
                        break;
                    default:
                        Console.WriteLine("Error: Something weird is going on. If you see this, please contact the developer.");
                        break;
                }
            }

            public enum DoorStatus { Open, Closed, Locked }
        }

        public enum CardColor { Red, Green, Blue, Yellow }
        public enum CardRank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Percent, Carrot, Ampersand }
    }
}