using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CST_227_Milestone
{
    class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool Visited { get; set; }
        public int Neighbors { get; set; }
        public bool Live { get; set; }

        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
            Neighbors = 0;
            Live = false;
            Visited = false;
        }
    }
}
