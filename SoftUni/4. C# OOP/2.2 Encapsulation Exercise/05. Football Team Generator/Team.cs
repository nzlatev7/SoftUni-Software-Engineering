using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5
{
    public class Team
    {
        private List<Player> players;

        private string name;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }
        public string Name 
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }
        public double Rating 
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }

                return players.Sum(p => p.SkillLevel) / players.Count;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            Player player = players.Find(x => x.Name == playerName);

            if (player == null)
            {
                throw new InvalidOperationException($"Player {playerName} is not in {Name} team.");
            }

            players.Remove(player);
        }
    }
}
