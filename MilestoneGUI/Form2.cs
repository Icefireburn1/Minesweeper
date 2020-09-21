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
    public partial class Form2 : Form
    {
        public static Board board;

        private static int selectedDifficultyBoardSize;
        public static int SelectedDifficultyBoardSize
        {
            get { return selectedDifficultyBoardSize; }
        }


        public Form2()
        {
            InitializeComponent();
        }



        private void playButton_Click(object sender, EventArgs e)
        {
            int dimension = 0;

            if (easyRadioButton.Checked)
            {
                dimension = 8;
                selectedDifficultyBoardSize = dimension;
            }
            else if (moderateRadioButton.Checked)
            {
                dimension = 16;
                selectedDifficultyBoardSize = dimension;
            }
            else if (difficultRadioButton.Checked)
            {
                dimension = 24;
                selectedDifficultyBoardSize = dimension;
            }


            board = new Board(dimension);
            board.setupLiveNeighbors(5);
            board.calculateLiveNeighbors();

            Form1 gameForm = new Form1();

            gameForm.Show();
            this.Hide();
        }
    }
}
