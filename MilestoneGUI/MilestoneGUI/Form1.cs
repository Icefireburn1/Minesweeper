using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilestoneGUI
{
    public partial class Form1 : Form
    {
        public Button[,] btnGrid = new Button[Form2.Dimension, Form2.Dimension];

        public Form1()
        {
            InitializeComponent();
            populateGrid();
        }

        public void populateGrid()
        {
            //this function will fill the panel1 control buttons
            int buttonSize = panel1.Width / Form2.Dimension;
            panel1.Height = panel1.Width;

            for (int r = 0; r < Form2.Dimension; r++)
            {
                for (int c = 0; c < Form2.Dimension; c++)
                {
                    btnGrid[r, c] = new Button();

                    // make each button a square
                    btnGrid[r, c].Width = buttonSize;
                    btnGrid[r, c].Height = buttonSize;

                    btnGrid[r, c].Click += Grid_Button_Click; // Add the same clicke event to each button
                    panel1.Controls.Add(btnGrid[r, c]); // place the button on the Panel
                    btnGrid[r, c].Location = new Point(buttonSize * r, buttonSize * c); // position it in x, y


                    // the tag attribute will hold the row and column number in a string
                    btnGrid[r, c].Tag = r.ToString() + "|" + c.ToString();
                }
            }
        }

        private void Grid_Button_Click(object sender, EventArgs e)
        {
            // Set the background color of the clicked button to something different.
            (sender as Button).BackColor = Color.Blue;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
