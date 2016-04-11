using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class TwoChildrenNode : Node

    {

        public Node FirstChild { get; }

        public Node SecondChild { get; }

        public TwoChildrenNode(string name, Node first, Node second) : base(name)
        {
            FirstChild = first;
            SecondChild = second;
        }

    }
}
