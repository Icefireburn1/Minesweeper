using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilestoneGUI
{
    public class PlayerStats : IComparable<PlayerStats>
    {
        public string PlayerName { get; set; }
        public string Difficulty { get; set; }
        public double TimeElapsed { get; set; }

        public int Score { get; set; }

        public PlayerStats(string playerName, string difficulty, double timeElapsed)
        {
            PlayerName = playerName;
            Difficulty = difficulty;
            TimeElapsed = timeElapsed;
        }

        public PlayerStats()
        {
            PlayerName = "Default";
            Difficulty = "Default";
            TimeElapsed = 0.0;
        }

        public void GenerateScore()
        {
            int multiplier = 1;
            switch (Difficulty)
            {
                case "Easy":
                    multiplier = 6;
                    break;
                case "Moderate":
                    multiplier = 3;
                    break;
                case "Difficult":
                    multiplier = 1;
                    break;
            }
            Score = (int)Math.Max(0, 10000 - (TimeElapsed * multiplier));
        }

        public int CompareTo(PlayerStats other)
        {
            if (this.Score == other.Score)
            {
                return this.PlayerName.CompareTo(other.PlayerName);
            }
            return other.Score.CompareTo(this.Score);
        }

        public override string ToString()
        {
            return PlayerName + " won in " + TimeElapsed.ToString("0.##") + " seconds on " + Difficulty + " with a score of " + Score;
        }
    }
}
