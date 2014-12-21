using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf
{
    public static class PlayersHelper
    {
        public static IEnumerable<Player> FindNeighbours(
            this Player currentPlayer,
            IEnumerable<Player> players,
            int no)
        {
            return players
                .Where(a => a != currentPlayer)
                .OrderBy(b => currentPlayer.Distance(b))
                .Take(no);
        }

        public static IEnumerable<Player> FindNeighbours(
            this Player currentPlayer,
            IEnumerable<Player> players,
            int no,
            IEnumerable<Player> ignored)
        {
            return players
                .Where(a => a != currentPlayer && !ignored.Contains(a))
                .OrderBy(b => currentPlayer.Distance(b))
                .Take(no);
        }

        public static Player FindRoot(
            this Player player,
            IEnumerable<Player> players,
            IEnumerable<Player> ignored
            )
        {
            var root = player.FindNeighbours(players, 1, ignored).Single();
            if (root.Coins == 0)
            {
                return root.FindRoot(players,
                    ignored.Concat(new[] { player }));
            }

            return root;
        }
    }
}
