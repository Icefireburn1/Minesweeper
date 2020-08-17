using System;

namespace CST_227_Milestone
{
    class Program
    {
        static Board board;
        static void Main(string[] args)
        {
            board = new Board(12);
            board.setupLiveNeighbors(5);
            board.calculateLiveNeighbors();
            printBoard(board.Grid);
        }

        // Prints grid
        private static void printBoard(Cell[,] grid)
        {
            // Header
            for (int x = 0; x < board.Size; x++)
            {
                // If # is less than 10 characters add space
                if (x < 10) 
                    Console.Write("| " + x + " ");
                else
                    Console.Write("| " + x);
            }
            Console.Write("|");
            Console.WriteLine();
            for (int x = 0; x < board.Size; x++)
            {
                Console.Write("____");
            }

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
            }
        }
    }
}
