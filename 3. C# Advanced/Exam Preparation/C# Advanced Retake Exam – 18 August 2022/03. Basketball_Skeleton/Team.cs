using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> players;
        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;

            players = new List<Player>();
        }

        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public int Count { get { return players.Count; } }

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }

            if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }

            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            players.Add(player);

            return $"Successfully added {player.Name} to the team. Remaining open positions: {--OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            var player = players.Find(x => x.Name == name);

            if (player == null)
            {
                return false;
            }

            OpenPositions++;
            players.Remove(player);
            return true;
        }

        public int RemovePlayerByPosition(string position)
        {
            int beforeCount = Count;

            int removedPlayersCount = players
                .RemoveAll(x => x.Position == position);

            OpenPositions += removedPlayersCount;

            return removedPlayersCount;
        }

        public Player RetirePlayer(string name)
        {
            var player = players.Find(x => x.Name == name);

            if (player == null)
            {
                return null;
            }

            player.Retired = true;

            return player;
        }

        public List<Player> AwardPlayers(int games)
        {
            return players
                .Where(x => x.Games >= games)
                .ToList();
        }

        public string Report()
        {
            StringBuilder teamInfo = new StringBuilder();

            teamInfo.AppendLine($"Active players competing for Team {Name} from Group {Group}:");

            foreach (var player in players
                .Where(x => x.Retired != true))
            {
                teamInfo.AppendLine(player.ToString());
            }

            return teamInfo.ToString().TrimEnd();
        }


    }
}
