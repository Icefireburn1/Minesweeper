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
    public partial class difficultyForm : Form
    {
        public static Board board;

        private static int selectedDifficultyBoardSize;
        public static int SelectedDifficultyBoardSize
        {
            get { return selectedDifficultyBoardSize; }
        }


        public difficultyForm()
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
                dimension = 10;
                selectedDifficultyBoardSize = dimension;
            }
            else if (difficultRadioButton.Checked)
            {
                dimension = 12;
                selectedDifficultyBoardSize = dimension;
            }


            board = new Board(dimension);
            board.setupLiveNeighbors(5);
            board.calculateLiveNeighbors();

            gameForm gameForm = new gameForm();

            gameForm.Show();
            this.Hide();
        }
    }
}
