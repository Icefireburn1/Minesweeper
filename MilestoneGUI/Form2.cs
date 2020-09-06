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
        private static int dimension = 0;
        public static int Dimension { get => dimension; set => dimension = value; }

        

        public Form2()
        {
            InitializeComponent();
        }



        private void playButton_Click(object sender, EventArgs e)
        {


            if (easyRadioButton.Checked)
                dimension = 8;
            else if (moderateRadioButton.Checked)
                dimension = 16;
            else if (difficultRadioButton.Checked)
                dimension = 24;

            Form1 gameForm = new Form1();

            gameForm.Show();
            this.Hide();
        }
    }
}
