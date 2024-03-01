using System;
using System.Text;

namespace Basketball
{
    public class Player
    {
        public Player(string name, string position, double rating, int games)
        {
            Name = name;
            Position = position;
            Rating = rating;
            Games = games;
        }

        public string Name { get; set; }
        public string Position { get; set; }
        public double Rating { get; set; }
        public int Games { get; set; }
        public bool Retired { get; set; } = false;

        public override string ToString()
        {
            StringBuilder playerInfo = new StringBuilder();

            playerInfo.AppendLine($"-Player: {Name}");
            playerInfo.AppendLine($"--Position: {Position}");
            playerInfo.AppendLine($"--Rating: {Rating}");
            playerInfo.AppendLine($"--Games played: {Games}");

            return playerInfo.ToString().TrimEnd();
        }
    }
}
