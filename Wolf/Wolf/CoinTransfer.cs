using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf
{
    [DebuggerDisplay("{From.Id}>>{To.Id} ({Distance}) Coins = {From.Coins} Executed = {Executed}")]
    public class CoinTransfer
    {
        public CoinTransfer(Player from, Player to)
        {
            From = from;
            To = to;
        }

        public Player From { get; private set; }
        public Player To { get; private set; }
        public bool Executed { get; set; }

        public double Distance
        {
            get
            {
                return From.Distance(To);
            }
        }
    }
}
