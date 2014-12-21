using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf
{
    public interface IClassificationNode
    {
        int DiedInRound { get; set; }
        IClassificationNode Root { get; set; }
        List<IClassificationNode> Children { get; }
    }
}
