using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilestoneGUI
{
    public partial class Form4 : Form
    {
        private static List<PlayerStats> people = new List<PlayerStats>();
        public Form4()
        {
            InitializeComponent();
            LoadStatsFromFile();
            foreach(PlayerStats p in people)
            {
                p.GenerateScore();
            }

            people.Sort();

            for (int i = 0; i < 5; i++)
            {
                if (people.Count <= i)
                {
                    break;
                }
                listBox1.Items.Add((i+1) + ". " + people[i]);
            }
        }

        private void LoadStatsFromFile()
        {
            string filePath = @"C:\Users\Justin\source\repos\MilestoneGUI\MilestoneGUI\stats.txt";
            List<String> lines = File.ReadAllLines(filePath).ToList();
            foreach (string line in lines)
            {
                string[] entries = line.Split(',');
                if (entries.Length != 3)
                {
                    Console.WriteLine("Error: Not enough columns (3)");
                    return;
                }

                PlayerStats p = new PlayerStats();
                p.PlayerName = entries[0];
                p.Difficulty = entries[1];

                // Check for numbers in third column
                double result;
                if (double.TryParse(entries[2], out result))
                {
                    p.TimeElapsed = result;
                }
                else
                {
                    MessageBox.Show("Error: Could not load 3rd column since it was not a decimal number.");
                    return;
                }

                people.Add(p);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Restarts the game
            Application.Restart();
            Environment.Exit(0);
        }
    }
}
