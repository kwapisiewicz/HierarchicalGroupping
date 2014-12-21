using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf
{
    public static class Config
    {
        /// <summary>
        /// Get S coins from bank
        /// </summary>        
        public const int S = 20;

        /// <summary>
        /// Number of neighbours to pass coin
        /// </summary>
        public const int N = 10;

        /// <summary>
        /// Return K coins to bank
        /// </summary>
        public const int K = 21;

        /// <summary>
        /// Game ends when found at most NoRoots
        /// </summary>
        public const int NoRoots = 2;

        public static List<Player> LoadPlayers()
        {
            var lines = Files.Iris.Split(
                new[] { '\n' },
                StringSplitOptions.RemoveEmptyEntries);
            List<Player> players = new List<Player>();
            for (int i = 0; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');
                Player p = new Player()
                {
                    Id = i + 1,
                    A = double.Parse(values[0], new CultureInfo("en-GB")),
                    B = double.Parse(values[1], new CultureInfo("en-GB")),
                    C = double.Parse(values[2], new CultureInfo("en-GB")),
                    D = double.Parse(values[3], new CultureInfo("en-GB")),
                    Class = values[4],
                };
                players.Add(p);
            }
            return players;
        }
    }
}
