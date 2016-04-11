using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class NodeTransformer:INodeTransformer
    {
        public Node Transform(Node node)
        {
            if (node as NoChildrenNode != null)
            {
                return node;
            }
            else if (node as ManyChildrenNode != null)
            {
                ManyChildrenNode mcd = (ManyChildrenNode)node;
                if (mcd.Children.Count() > 2)
                {
                    ManyChildrenNode root = new ManyChildrenNode(mcd.Name, mcd.Children.ToArray());
                    foreach (var cnode in mcd.Children)
                        Transform(cnode);
                    return root;
                }
                else if (mcd.Children.Count() == 2)
                {
                    List<Node> lchildren = mcd.Children.ToList();
                    TwoChildrenNode tcn = new TwoChildrenNode(mcd.Name, Transform(lchildren[0]), Transform(lchildren[1]));
                    return tcn;
                }
                else if (mcd.Children.Count() == 1)
                {
                    List<Node> child = mcd.Children.ToList();
                    //Transform(child[0]);
                    SingleChildNode scn = new SingleChildNode(mcd.Name, Transform(child[0]));
                    return scn;
                }
                else
                {
                    NoChildrenNode ncn = new NoChildrenNode(mcd.Name);
                    return ncn;
                }
            }
            else if (node as TwoChildrenNode != null)
            {
                TwoChildrenNode tcd = (TwoChildrenNode)node;
                if ((tcd.FirstChild != null) && (tcd.SecondChild != null))
                {
                    TwoChildrenNode ntcn = new TwoChildrenNode(tcd.Name, tcd.FirstChild, tcd.SecondChild);
                    Transform(ntcn.FirstChild);
                    Transform(ntcn.SecondChild);
                    return ntcn;
                }
                else if ((tcd.FirstChild == null) && (tcd.SecondChild == null))
                {
                    NoChildrenNode ncn = new NoChildrenNode(tcd.Name);
                    return ncn;
                }
                else if ((tcd.FirstChild == null) || (tcd.SecondChild == null))
                {
                    SingleChildNode scn;
                    if (tcd.FirstChild != null)
                    {
                         scn = new SingleChildNode(tcd.Name, tcd.FirstChild);
                    }
                    else
                    {
                        scn = new SingleChildNode(tcd.Name,tcd.SecondChild);
                    }
                    Transform(scn);
                    return scn;
                }   
            }
            else if (node as SingleChildNode != null)
            {
                SingleChildNode scn = (SingleChildNode)node;
                if (scn.Child == null)
                {
                    NoChildrenNode ncn = new NoChildrenNode(scn.Name);
                    return ncn;
                }
                Transform(scn);
                return scn;
            }
            return node;
        } 
    }
}
