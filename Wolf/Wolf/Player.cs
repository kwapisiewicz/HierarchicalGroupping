using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf
{
    [DebuggerDisplay("Id = {Id} Coins = {Coins} Children={Children.Count} Class = {Class} {A} {B} {C} {D}")]
    public class Player : IClassificationNode
    {
        public Player()
        {
            Children = new List<IClassificationNode>();
        }

        public int Id { get; set; }
        public string Class { get; set; }
        public int Coins { get; set; }

        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }

        public double Distance(Player player)
        {
            double dA2 = Math.Pow(Math.Abs(player.A - this.A), 2);
            double dB2 = Math.Pow(Math.Abs(player.B - this.B), 2);
            double dC2 = Math.Pow(Math.Abs(player.C - this.C), 2);
            double dD2 = Math.Pow(Math.Abs(player.D - this.D), 2);
            return Math.Sqrt(dA2 + dB2 + dC2 + dD2);
        }

        public int DiedInRound { get; set; }

        public IClassificationNode Root { get; set; }

        public List<IClassificationNode> Children { get; private set; }
    }
}
