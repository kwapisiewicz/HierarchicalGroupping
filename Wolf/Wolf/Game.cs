using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf
{
    public class Game
    {
        public void ExecuteRound(IEnumerable<Player> players)
        {
            AddCoins(players);

            List<CoinTransfer> allTransfersInRound = GetTransfers(players);

            allTransfersInRound.Sort((a, b) => a.Distance.CompareTo(b.Distance));
            
            bool allExecuted = false;
            while (!allExecuted)
            {
                foreach (var transfer in allTransfersInRound
                    .Where(a=>!a.Executed))
                {
                    ExecuteTransfer(transfer);
                }

                allExecuted = allTransfersInRound
                    .Any(a => a.Executed && a.From.Coins > 0);
            }

            ReturnCoins(players);
        }

        private List<CoinTransfer> GetTransfers(IEnumerable<Player> players)
        {
            List<CoinTransfer> transfersInRound = new List<CoinTransfer>();
            foreach (var currentPlayer in players)
            {
                var transfersFromCurrentPlayer =
                    currentPlayer.FindNeighbours(players, Config.N)
                    .Select(neighbour => new CoinTransfer(currentPlayer, neighbour));
                transfersInRound.AddRange(transfersFromCurrentPlayer);
            }
            return transfersInRound;
        }

        private bool ExecuteTransfer(CoinTransfer transfer)
        {
            if (transfer.From.Coins > 0)
            {
                transfer.From.Coins--;
                transfer.To.Coins++;
                transfer.Executed = true;
            }
            return transfer.Executed;
        }

        private void ReturnCoins(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                player.Coins -= Math.Min(player.Coins, Config.K);
            }
        }

        private void AddCoins(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                player.Coins += Config.S;
            }
        }
    }
}
