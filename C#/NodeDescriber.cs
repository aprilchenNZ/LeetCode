using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class NodeDescriber: INodeDescriber
    {
        public string Describe(Node node)
        {
            const string title = "result is:";
            StringBuilder sb = new StringBuilder();
            sb.Append(title);
            if (node == null)
                return sb.ToString();
            sb.Append(Subdescribe(node,0));
            return sb.ToString();
        }

        private string Subdescribe(Node node, int count)
        {
            string result = "";
            result += Environment.NewLine;
            string spaces = "";
            for (int i = 0; i < count; i++)
            {
                spaces += "    ";
            }
            result += spaces;
            if (node as NoChildrenNode != null)
            {
                NoChildrenNode ncn = (NoChildrenNode)node;
                result += "new NoChildrenNode(" + node.Name + ")";
            }
            else if (node as SingleChildNode != null)   
            {
                SingleChildNode scn = (SingleChildNode)node;
                result += "new SingleChildNodef(" + node.Name + ",";
                result += Subdescribe(scn.Child, count + 1);
                result += ")";
            }
            else if (node as TwoChildrenNode != null)
            {
                TwoChildrenNode wcn = (TwoChildrenNode)node;
                result += "new TwoChildrenNode(" + node.Name + ",";
                result += Subdescribe(wcn.FirstChild, count + 1);
                result += Subdescribe(wcn.SecondChild, count + 1);
                result += ")";
            }
            else if(node as ManyChildrenNode != null)
            {
                ManyChildrenNode mcn = (ManyChildrenNode)node;
                List<Node> child = mcn.Children.ToList();
                result += "new ManyChildrenNode(" + node.Name + ",";
                    foreach(var cnode in child)
                result += Subdescribe(cnode, count + 1);
                result += ")";
            }
            return result;
        }
    }
}
