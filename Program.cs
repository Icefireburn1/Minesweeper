using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace CST_227_Milestone
{
    class Program
    {
        static Board board;
        static void Main(string[] args)
        {
            bool defeat = false;
            bool victory = false;
            board = new Board(5);
            board.setupLiveNeighbors(5);
            board.calculateLiveNeighbors();

            while (!defeat && !victory)
            {
                int[] input = getInput();
                if (input == null)
                    continue;

                Cell visitedCell = board.Grid[input[0], input[1]];  // Selected cell
                visitedCell.Visited = true;

                if (visitedCell.Live) defeat = true; // Player found a bomb and lost
                if (victoryAchieved(board.Grid)) victory = true;


                //printBoard(board.Grid); // Use for debugging
                printBoardDuringGame(board.Grid); // Print game board
            }

            if (defeat)
                Console.WriteLine("You triggered a bomb and lost!");

            if (victory)
                Console.WriteLine("Congratulations! You avoided all the bombs!");
        }

        // Prints grid and shows all cells
        private static void printBoard(Cell[,] grid)
        {
            // Header
            for (int x = 0; x < board.Size; x++)
            {
                // If # is less than 10 characters add space
                if (x < 10) 
                    Console.Write("+ " + x + " ");
                else
                    Console.Write("+ " + x);
            }
            Console.Write("+");
            Console.WriteLine();
            for (int x = 0; x < board.Size; x++)
            {
                Console.Write("+---");
            }
            Console.Write("+");

            // Print cells
            for (int x = 0; x < board.Size; x++)
            {
                Console.WriteLine();
                for (int y = 0; y < board.Size; y++)
                {
                    // Print symbol if cell is live
                    if (board.Grid[x, y].Live)
                        Console.Write("| {0} ", "@");
                    else
                        Console.Write("| {0} ", board.Grid[x, y].Neighbors);
                }
                Console.Write("| " + x);
                Console.WriteLine();
                for (int y = 0; y < board.Size; y++)
                {
                    Console.Write("+---");
                }
                Console.Write("+");
            }
            Console.WriteLine();
        }

        // Live preview of gameboard
        private static void printBoardDuringGame(Cell[,] grid)
        {
            // Header
            for (int x = 0; x < board.Size; x++)
            {
                // If # is less than 10 characters add space
                if (x < 10)
                    Console.Write("+ " + x + " ");
                else
                    Console.Write("+ " + x);
            }
            Console.Write("+");
            Console.WriteLine();
            for (int x = 0; x < board.Size; x++)
            {
                Console.Write("+---");
            }
            Console.Write("+");

            // Print cells
            for (int x = 0; x < board.Size; x++)
            {
                Console.WriteLine();

                // Handles printing of symbols
                for (int y = 0; y < board.Size; y++)
                {
                    // Cell isn't visited
                    if (!board.Grid[x, y].Visited)
                        Console.Write("| {0} ", "?");
                    // Cell is live
                    else if (board.Grid[x, y].Live)
                        Console.Write("| {0} ", "@");
                    // Cell has no neighbors
                    else if (board.Grid[x, y].Neighbors == 0)
                        Console.Write("| {0} ", " ");
                    // Cell has neighbors
                    else
                        Console.Write("| {0} ", board.Grid[x, y].Neighbors);
                }
                Console.Write("| " + x);
                Console.WriteLine();
                for (int y = 0; y < board.Size; y++)
                {
                    Console.Write("+---");
                }
                Console.Write("+");
            }
            Console.WriteLine();
        }

        // Returns 2D array for purpose of player input
        private static int[] getInput()
        {
            int numberRow = -1;
            int numberCol = -1;

            Console.Write("Please provide a column number from 0-{0}: ", board.Size - 1);
            if (int.TryParse(Console.ReadLine(), out numberCol) == false || numberCol > board.Size - 1 || numberCol < 0)
            {
                Console.WriteLine("Error: invalid input");
                return null;
            }

            Console.Write("Please provide a row number from 0-{0}: ", board.Size - 1);
            if (int.TryParse(Console.ReadLine(), out numberRow) == false || numberRow > board.Size - 1 || numberRow < 0)
            {
                Console.WriteLine("Error: invalid input");
                return null;
            }

            return new int[] { numberRow, numberCol};
        }

        // Has the player won yet?
        private static bool victoryAchieved(Cell[,] cell)
        {
            for (int x = 0; x < board.Size; x++)
            {
                for (int y = 0; y < board.Size; y++)
                {
                    // If we found an unvisited non-bomb, we haven't won yet
                    if (!cell[x, y].Live && !cell[x, y].Visited)
                        return false;
                }
            }

            return true;
        }
    }
}
