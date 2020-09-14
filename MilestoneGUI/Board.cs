using System;
using System.Collections.Generic;
using System.Text;

namespace MilestoneGUI
{
    public class Board
    {
        public int Size { get; set; }
        public Cell[,] Grid { get; set; }
        public int Difficulty { get; set; }

        public Board(int size)
        {
            Size = size;
            Grid = new Cell[Size, Size];
            Difficulty = 0;
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    Grid[x, y] = new Cell(x, y);
                }
            }
        }

        // Decide which cells will become live (bombs)
        public void setupLiveNeighbors(int difficulty)
        {
            Random ran = new Random();
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    int chance = ran.Next(0, 100);

                    // We only make the bomb live if our random number is <= to our difficulty
                    if (chance <= difficulty)
                        Grid[x, y].Live = true;
                }
            }
        }

        // Generates the # of neighbors for each cell
        public void calculateLiveNeighbors()
        {
            int count;
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    // Cell is live, set to 9
                    if (Grid[x, y].Live)
                    {
                        Grid[x, y].Neighbors = 9;
                        continue;
                    }
                    // Reset after each loop
                    count = 0;

                    // Calculate neighbors
                    // Left neighobrs
                    if ((x - 1 >= 0) && (y - 1 >= 0) && Grid[x - 1, y - 1].Live) count++;
                    if ((x - 1 >= 0) && Grid[x - 1, y].Live) count++;
                    if ((x - 1 >= 0) && (y + 1 < Size-1) && Grid[x - 1, y + 1].Live) count++;

                    // Right neighbors
                    if ((x + 1 < Size-1) && (y - 1 >= 0) && Grid[x + 1, y - 1].Live) count++;
                    if ((x + 1 < Size-1) && Grid[x + 1, y].Live) count++;
                    if ((x + 1 < Size-1) && (y + 1 < Size-1) && Grid[x + 1, y + 1].Live) count++;

                    // Top/Bottom neighbors
                    if ((y - 1 >= 0) && Grid[x, y - 1].Live) count++;
                    if ((y + 1 < Size-1) && Grid[x, y + 1].Live) count++;

                    Grid[x, y].Neighbors = count;
                }
            }
        }

        public void floodFill(int row, int col)
        {
            if (row < 0 || row >= Size || col < 0 || col >= Size || Grid[row, col].Live || Grid[row, col].Visited || Grid[row, col].Neighbors > 0)
                return;

            Grid[row, col].Visited = true;

            floodFill(row+1, col);
            floodFill(row-1, col);
            floodFill(row, col+1);
            floodFill(row, col-1);
        }
    }
}
