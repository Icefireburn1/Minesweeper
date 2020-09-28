using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilestoneGUI
{
    public partial class recordResultForm : Form
    {
        private Stopwatch watch;

        public recordResultForm(Stopwatch watch)
        {
            InitializeComponent();
            label1.Text = "You Win!\n" + "Time elapsed: " + watch.Elapsed.TotalMilliseconds / 1000 + " seconds";
            this.watch = watch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddResultToFile();
            highscoreForm highScore = new highscoreForm();
            highScore.Show();
            this.Dispose();
        }

        private void AddResultToFile()
        {
            string filePath = @"C:\Users\Justin\source\repos\MilestoneGUI\MilestoneGUI\stats.txt";
            if (!File.Exists(filePath))
            {
                CreateFirstEntry(filePath);
            }
            else
            {
                PutEntriesInFile(filePath);
            }
        }

        private void PutEntriesInFile(string filePath)
        {
            List<PlayerStats> people = LoadStatsFromFile();
            
            List<string> outputLines = new List<string>();
            foreach (PlayerStats p in people)
            {
                outputLines.Add(p.PlayerName + "," + p.Difficulty + "," + p.TimeElapsed);
            }

            string difficulty = "Null";
            switch (difficultyForm.SelectedDifficultyBoardSize)
            {
                case 8:
                    difficulty = "Easy";
                    break;
                case 10:
                    difficulty = "Moderate";
                    break;
                case 12:
                    difficulty = "Hard";
                    break;
            }

            PlayerStats stat = new PlayerStats(textBox1.Text, difficulty, watch.Elapsed.TotalMilliseconds / 1000);
            outputLines.Add(stat.PlayerName + "," + stat.Difficulty + "," + stat.TimeElapsed);

            File.WriteAllLines(filePath, outputLines);
        }

        private List<PlayerStats> LoadStatsFromFile()
        {
            List<PlayerStats> people = new List<PlayerStats>();
            string filePath = @"C:\Users\Justin\source\repos\MilestoneGUI\MilestoneGUI\stats.txt";
            List<String> lines = File.ReadAllLines(filePath).ToList();
            foreach (string line in lines)
            {
                string[] entries = line.Split(',');
                if (entries.Length != 3)
                {
                    Console.WriteLine("Error: Not enough columns (3)");
                    return null; ;
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
                    return null;
                }

                people.Add(p);
            }

            return people;
        }

        private void CreateFirstEntry(string filePath)
        {
            string difficulty = "Null";
            switch (difficultyForm.SelectedDifficultyBoardSize)
            {
                case 8:
                    difficulty = "Easy";
                    break;
                case 16:
                    difficulty = "Moderate";
                    break;
                case 24:
                    difficulty = "Hard";
                    break;
            }

            PlayerStats stat = new PlayerStats(textBox1.Text, difficulty, watch.Elapsed.TotalMilliseconds / 1000);
            // entry will be used to save the file
            File.WriteAllText(filePath, stat.PlayerName + "," + stat.Difficulty + "," + stat.TimeElapsed + "\n");
        }
    }
}
