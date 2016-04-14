using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class NodeDesFactory
    {
        public static INodeDescriber NodeDescriberimp { get; set; }

        public static INodeDescriber GetNodeDescriber()
        {
            if (NodeDescriberimp == null)
                NodeDescriberimp = new NodeDescriber();
            return NodeDescriberimp;
        }
    }
}
