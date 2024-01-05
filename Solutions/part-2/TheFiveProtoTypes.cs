using System.Reflection.Metadata;

namespace LearningProgram.Solutions
{
    public partial class Level24
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

        public static void TheLockedDoor()
        {
            int Passcode = Toolbox.AskForNumber("Please enter your initial passcode: ");
            Door CurrentDoor = new Door(Passcode);
            while (true)
            {
                string UserChoice = Toolbox.AskForString($"Choose an action: 'Close' the door, 'Open' the door, 'Lock' the door', 'Unlock' the door, 'Check' the door status, or 'Change' the passkey.");

                switch (UserChoice.ToLower())
                {
                    case "close":
                        CurrentDoor.CloseDoor();
                        break;
                    case "open":
                        CurrentDoor.OpenDoor();
                        break;
                    case "lock":
                        CurrentDoor.LockDoor();
                        break;
                    case "unlock":
                        int InputCode = Toolbox.AskForNumber("Please enter your passcode: ");
                        CurrentDoor.UnlockDoor(InputCode);
                        break;
                    case "change":
                        int CurrentCode = Toolbox.AskForNumber("Please enter your current passcode: ");
                        int NewCode = Toolbox.AskForNumber("Please enter your new passcode: ");
                        CurrentDoor.ChangePasscode(CurrentCode, NewCode);
                        break;
                    case "check":
                        DoorStatus CurrentState = CurrentDoor.GetState();
                        Console.WriteLine($"The door is currently in state: {CurrentState}");
                        break;
                    default:
                        Console.WriteLine("Sorry? I didn't quite catch that. Can you pick something from the list for me?");
                        break;
                }
            }
        }

        public static void ThePasswordValidator()
        {
            while (true)
            {
                PasswordValidator Password = new PasswordValidator(Toolbox.AskForString("Please enter the password to be tested: "));
                if (Password.ValidPassword) { Console.WriteLine("Password is valid"); }
                else { Console.WriteLine("Password is NOT valid."); }
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

        class Door
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
                switch (this.CurrentState)
                {
                    case DoorStatus.Locked:
                        if (this.Passcode == Passcode)
                        {
                            this.CurrentState = DoorStatus.Closed;
                            Console.WriteLine("Door unlocked");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Error: Input for current passcode does not match stored code!");
                            break;
                        }
                    case DoorStatus.Closed:
                        Console.WriteLine("Error: The door is already unlocked!");
                        break;
                    case DoorStatus.Open:
                        Console.WriteLine("Error: The door is already open!");
                        break;
                    default:
                        Console.WriteLine("Error: Something weird is going on. If you see this, please contact the developer.");
                        break;
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
            public void CloseDoor()
            {
                switch (this.CurrentState)
                {
                    case DoorStatus.Open:
                        this.CurrentState = DoorStatus.Closed;
                        Console.WriteLine("Door closed.");
                        break;
                    case DoorStatus.Closed:
                        Console.WriteLine("Error: The door is already closed!");
                        break;
                    case DoorStatus.Locked:
                        Console.WriteLine("Error: The door is already locked!");
                        break;
                    default:
                        Console.WriteLine("Error: Something weird is going on. If you see this, please contact the developer.");
                        break;
                }
            }
        }

        class PasswordValidator
        {
            public string Password { get; set; }
            public bool ValidPassword
            {
                get
                {
                    if (ContainsLower && ContainsUpper && ContainsNumber && !ContainsTChar && !ContainsAmpChar && ValidLength) { return true; }
                    else { return false; }
                }
            }

            public PasswordValidator(string Input)
            {
                this.Password = Input;
            }

            private bool ContainsLower
            {
                get
                {
                    bool CurrentValue = false;
                    foreach (char letter in this.Password)
                    {
                        if (char.IsLower(letter)) { CurrentValue = true; }
                    }
                    return CurrentValue;
                }
            }

            private bool ContainsUpper
            {
                get
                {
                    bool CurrentValue = false;
                    foreach (char letter in this.Password)
                    {
                        if (char.IsUpper(letter)) { CurrentValue = true; }
                    }
                    return CurrentValue;
                }
            }

            private bool ContainsNumber
            {
                get
                {
                    bool CurrentValue = false;
                    foreach (char letter in this.Password)
                    {
                        if (char.IsNumber(letter)) { CurrentValue = true; }
                    }
                    return CurrentValue;
                }
            }

            private bool ContainsTChar
            {
                get
                {
                    bool CurrentValue = false;
                    foreach (char letter in this.Password)
                    {
                        if (letter == 'T') { CurrentValue = true; }
                    }
                    return CurrentValue;
                }
            }

            private bool ContainsAmpChar
            {
                get
                {
                    bool CurrentValue = false;
                    foreach (char letter in this.Password)
                    {
                        if (letter == '&') { CurrentValue = true; }
                    }
                    return CurrentValue;
                }
            }

            private bool ValidLength
            {
                get
                {
                    if (this.Password.Length >= 6 && this.Password.Length <= 13) { return true; }
                    else { return false; }
                }
            }
        }

        public enum CardColor { Red, Green, Blue, Yellow }
        public enum CardRank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Percent, Carrot, Ampersand }
        public enum DoorStatus { Open, Closed, Locked }
    }
}