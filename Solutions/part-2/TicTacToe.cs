// Class Game
// Displays grid - valid characters are "X", "O" and " ".
// Checks grid vertically, horizontally, and diagonally for matching characters
// Access grid elements
// If the board is full (i.e., no remaining " " cells, and there is not a winner, then there is a DRAW)

namespace LearningProgram.Solutions
{
    public partial class Level24
    {
        public static void TicTacToe()
        {
            char[,] InitialGrid = {
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' }
            };

            Grid GameBoard = new Grid(InitialGrid);

            DisplayBoard(GameBoard.grid);
        }

        public static void DisplayBoard(char[,] board)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(board[row, col]);

                    if (col < 2)
                        Console.Write(" | ");
                }

                Console.WriteLine();

                if (row < 2)
                    Console.WriteLine("---------");
            }
        }
    }

    // Class Grid: Imported from my Advent of Code work and reused here.
    public class Grid
    {
        public char[,] grid { get; }
        private int currentRow;
        private int currentCol;
        public char currentElement
        {
            get
            {
                if (IsValidPosition(currentRow, currentCol)) { return GetElement(currentRow, currentCol); }
                else { throw new IndexOutOfRangeException("Position exceeds grid boundaries"); } // Invalid position handling
            }
        }
        public (int Row, int Col) currentPosition
        {
            get
            {
                if (IsValidPosition(currentRow, currentCol)) { return (currentRow, currentCol); }
                else { throw new IndexOutOfRangeException("Position exceeds grid boundaries"); } // Invalid position handling
            }
        }

        public Grid(string[] input)
        {
            // Initialize grid from input strings
            int rows = input.Length;
            int cols = input[0].Length;
            grid = new char[rows, cols];

            // Set grid data to input grid data
            for (int rowNum = 0; rowNum < rows; rowNum++)
            {
                for (int colNum = 0; colNum < cols; colNum++)
                {
                    grid[rowNum, colNum] = input[rowNum][colNum];
                }
            }

            // Set initial position
            currentRow = 0;
            currentCol = 0;
        }

        public Grid(char[,] input)
        {
            // Import grid of characters
            grid = input;

            // Set initial position
            currentRow = 0;
            currentCol = 0;
        }

        public char GetElement(int row, int col)
        {
            // Return element at specified position
            return grid[row, col];
        }

        public void SetElement(int row, int col, char input)
        {
            if (IsValidPosition(row, col))
            {
                // Set grid position to given character
                grid[row, col] = input;
            }
        }

        public bool IsValidPosition(int row, int col)
        {
            return row >= 0 && row < grid.GetLength(0) && col >= 0 && col < grid.GetLength(1);
        }

        public NeighborInfo[] GetNeighbors(int row, int col)
        {
            List<NeighborInfo> neighbors = new List<NeighborInfo>();

            // Check vertically, horizontally, and diagonally for characters
            for (int rowNum = row - 1; rowNum <= row + 1; rowNum++)
            {
                for (int colNum = col - 1; colNum <= col + 1; colNum++)
                {
                    if (rowNum == row && colNum == col)
                    {
                        // Skip current position
                        continue;
                    }
                    else if (IsValidPosition(rowNum, colNum))
                    {
                        char character = GetElement(rowNum, colNum);
                        neighbors.Add(new NeighborInfo { Row = rowNum, Col = colNum, Character = character });
                    }
                }
            }

            return neighbors.ToArray();
        }

        public void MovePosition(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (IsValidPosition(currentRow - 1, currentCol)) { currentRow--; }
                    else { throw new IndexOutOfRangeException("Position exceeds grid boundaries"); }
                    break;
                case Direction.Down:
                    if (IsValidPosition(currentRow + 1, currentCol)) { currentRow++; }
                    else { throw new IndexOutOfRangeException("Position exceeds grid boundaries"); }
                    break;
                case Direction.Left:
                    if (IsValidPosition(currentRow, currentCol - 1)) { currentCol--; }
                    else { throw new IndexOutOfRangeException("Position exceeds grid boundaries"); }
                    break;
                case Direction.Right:
                    if (IsValidPosition(currentRow, currentCol + 1)) { currentCol++; }
                    else { throw new IndexOutOfRangeException("Position exceeds grid boundaries"); }
                    break;
                case Direction.UpLeft:
                    if (IsValidPosition(currentRow - 1, currentCol - 1)) { currentRow--; currentCol--; }
                    else { throw new IndexOutOfRangeException("Position exceeds grid boundaries"); }
                    break;
                case Direction.UpRight:
                    if (IsValidPosition(currentRow - 1, currentCol + 1)) { currentRow--; currentCol++; }
                    else { throw new IndexOutOfRangeException("Position exceeds grid boundaries"); }
                    break;
                case Direction.DownLeft:
                    if (IsValidPosition(currentRow + 1, currentCol - 1)) { currentRow++; currentCol--; }
                    else { throw new IndexOutOfRangeException("Position exceeds grid boundaries"); }
                    break;
                case Direction.DownRight:
                    if (IsValidPosition(currentRow + 1, currentCol + 1)) { currentRow++; currentCol++; }
                    else { throw new IndexOutOfRangeException("Position exceeds grid boundaries"); }
                    break;
                default:
                    // Handle unexpected direction
                    break;
            }
        }
        public void SetPosition(int row, int col)
        {
            if (IsValidPosition(row, col)) { currentRow = row; currentCol = col; }
            else { throw new IndexOutOfRangeException("Position exceeds grid boundaries"); }
        }

        public enum Direction { Up, Down, Left, Right, UpLeft, UpRight, DownLeft, DownRight }
    }

    public class NeighborInfo
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public char Character { get; set; }

        public NeighborInfo()
        {
            Row = 0;
            Col = 0;
            Character = '\0';
        }
    }

}


// Class GridInput
// State which player is currently playing ("X" or "O")
// Takes input from the player (Take current player as parameter)
//  Check if square is already occupied; If it is, then tell the player of the problem, and give another chance
