using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilestoneGUI
{
    public partial class gameForm : Form
    {
        public Button[,] btnGrid = new Button[difficultyForm.board.Size, difficultyForm.board.Size];
        public static Stopwatch watch = new Stopwatch();
        
        public static bool victory = false;

        public gameForm()
        {
            InitializeComponent();
            populateGrid();
            watch.Start();
        }

        public void populateGrid()
        {
            //this function will fill the panel1 control buttons
            int buttonSize = panel1.Width / difficultyForm.board.Size;
            panel1.Height = panel1.Width;

            for (int r = 0; r < difficultyForm.board.Size; r++)
            {
                for (int c = 0; c < difficultyForm.board.Size; c++)
                {
                    btnGrid[r, c] = new Button();

                    // make each button a square
                    btnGrid[r, c].Width = buttonSize;
                    btnGrid[r, c].Height = buttonSize;

                    btnGrid[r, c].MouseDown += panel1_MouseDown; // Add the same click event to each button
                    panel1.Controls.Add(btnGrid[r, c]); // place the button on the Panel
                    btnGrid[r, c].Location = new Point(buttonSize * r, buttonSize * c); // position it in x, y


                    // the tag attribute will hold the row and column number in a string
                    btnGrid[r, c].Tag = r.ToString() + "|" + c.ToString();
                }
            }
        }

        // Has the player won yet?
        private static bool victoryAchieved(Cell[,] cell)
        {
            for (int x = 0; x < difficultyForm.board.Size; x++)
            {
                for (int y = 0; y < difficultyForm.board.Size; y++)
                {
                    // If we found an unvisited non-bomb, we haven't won yet
                    if (!cell[x, y].Live && !cell[x, y].Visited)
                        return false;
                }
            }

            return true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                HandleLeftClick(sender);
            if (e.Button == MouseButtons.Right)
                HandleRightClick(sender);
        }

        private void HandleRightClick(object sender)
        {
            Button btn = (Button)sender;
            string[] strArr = btn.Tag.ToString().Split('|');
            int r = int.Parse(strArr[0]);
            int c = int.Parse(strArr[1]);

            if (btnGrid[r, c].Image == null)
            {
                Image flag = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\flag.png");
                btnGrid[r, c].Image = (Image)(new Bitmap(flag, new Size(panel1.Width / difficultyForm.board.Size, panel1.Width / difficultyForm.board.Size))); // Resizes the image
            }
            else
            {
                btnGrid[r, c].Image = null;
            }

        }

        private void HandleLeftClick(object sender)
        {
            if (victory)
                return;

            Button btn = (Button)sender;
            string[] strArr = btn.Tag.ToString().Split('|');
            int r = int.Parse(strArr[0]);
            int c = int.Parse(strArr[1]);

            Cell visitedCell = difficultyForm.board.Grid[r, c];

            // Check for flag placed on cell, disallow clicking if flag is found
            if (btnGrid[r, c].Image != null)
                return;
            
            if (visitedCell.Neighbors > 0 && !visitedCell.Live)
            {
                visitedCell.Visited = true;
                btn.Text = visitedCell.Neighbors.ToString();
                btn.BackColor = Color.Thistle;
            }
            else if (visitedCell.Neighbors == 0)
            {
                difficultyForm.board.floodFill(r, c);
                for (int i = 0; i < difficultyForm.board.Size; i++)
                {
                    for (int b = 0; b < difficultyForm.board.Size; b++)
                    {
                        if (difficultyForm.board.Grid[i, b].Visited)
                        {
                            if (difficultyForm.board.Grid[i, b].Neighbors == 0)
                                btnGrid[i, b].BackColor = Color.PowderBlue;
                        }
                    }
                }
            }

            CheckForGameEnd(visitedCell);
        }

        void CheckForGameEnd(Cell visitedCell)
        {
            // Game Outcomes
            // Defeat
            if (visitedCell.Live)
            {
                // Show highscore form
                highscoreForm highScore = new highscoreForm();
                highScore.Show();

                MessageBox.Show("Game Over");

                // Run code to reveal everything
                for (int x = 0; x < difficultyForm.board.Size; x++)
                {
                    for (int y = 0; y < difficultyForm.board.Size; y++)
                    {
                        // Bomb
                        if (difficultyForm.board.Grid[x, y].Live)
                        {
                            Image bomb = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\mine.png");
                            btnGrid[x, y].Image = (Image)(new Bitmap(bomb, new Size(panel1.Width / difficultyForm.board.Size, panel1.Width / difficultyForm.board.Size))); // Resizes the image
                            btnGrid[x, y].BackColor = Color.Thistle;
                        }
                        // Cells with neighbors
                        else if (difficultyForm.board.Grid[x, y].Neighbors < 9 && difficultyForm.board.Grid[x, y].Neighbors > 0)
                        {
                            btnGrid[x, y].Text = difficultyForm.board.Grid[x, y].Neighbors.ToString();
                            btnGrid[x, y].BackColor = Color.Thistle;
                        }
                        // Cells with no neighbors
                        else if (difficultyForm.board.Grid[x, y].Neighbors == 0)
                        {
                            btnGrid[x, y].BackColor = Color.PowderBlue;
                        }
                    }
                }
            }

            // Victory
            if (victoryAchieved(difficultyForm.board.Grid))
            {
                victory = true;
                ShowMyDialogBox();
                watch.Stop();

                // Run code to reveal bombs
                for (int x = 0; x < difficultyForm.board.Size; x++)
                {
                    for (int y = 0; y < difficultyForm.board.Size; y++)
                    {
                        if (difficultyForm.board.Grid[x, y].Live)
                        {
                            Image bomb = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\flag.png");
                            btnGrid[x, y].Image = (Image)(new Bitmap(bomb, new Size(panel1.Width / difficultyForm.board.Size, panel1.Width / difficultyForm.board.Size))); // Resizes the image
                            btnGrid[x, y].BackColor = Color.Thistle;
                        }
                    }
                }
            }
        }

        public void ShowMyDialogBox()
        {
            recordResultForm nameGetter = new recordResultForm(watch);
            nameGetter.Show();
        }
    }
}
