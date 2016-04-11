using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ManyChildrenNode : Node

    {

        public IEnumerable<Node> Children { get; }

        public ManyChildrenNode(string name, params Node[] children) : base(name)

        {
            Children = children;
        }

    }
}
