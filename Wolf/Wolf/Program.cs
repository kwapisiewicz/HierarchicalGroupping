using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Wolf
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> allPlayers = Config.LoadPlayers();
            var game = new Game();

            List<Player> currentRoundPlayers = allPlayers;
            Console.WriteLine(currentRoundPlayers.Count());
            int i = 0;
            while (currentRoundPlayers.Count() > Config.NoRoots)
            {
                i++;
                game.ExecuteRound(currentRoundPlayers);
                var excluded = currentRoundPlayers
                    .Where(a => a.Coins <= 0);

                foreach (var item in excluded)
                {
                    var root = item.FindRoot(
                        currentRoundPlayers,
                        Enumerable.Empty<Player>());

                    root.Children.Add(item);
                    item.Root = root;
                    item.DiedInRound = i;
                }

                currentRoundPlayers = allPlayers
                    .Where(a => a.Coins > 0)
                    .ToList();

                int currentNo = CountReachableNodes(currentRoundPlayers);

                Console.WriteLine("Left: {0} Children: {1} All {2}",
                    currentRoundPlayers.Count(),
                    currentRoundPlayers.Sum(a => a.Children.Count),
                    currentNo);
            }

            Console.WriteLine("Iterations required to find at most {0} roots: {1}", Config.NoRoots, i);
            Console.ReadKey();
        }

        private static int CountReachableNodes(IEnumerable<Player> currentRoundPlayers)
        {
            int currentNo = 0;
            foreach (var item in currentRoundPlayers)
            {
                Count(item, ref currentNo);
            };
            return currentNo;
        }

        public static void Count(IClassificationNode node, ref int i)
        {
            i++;
            foreach (var item in node.Children)
            {
                Count(item, ref i);
            }
        }
    }
}
