using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    class NodeWriter: INodeWriter
    {
        INodeDescriber inodedes;
        public NodeWriter(INodeDescriber inodedes)
        {
            this.inodedes = inodedes;
        }

        public Task WriteToFileAsync(Node node, string filePath)
        {
            NodeDescriber nd = new NodeDescriber();
            Task t = Task.Factory.StartNew( ()=> {
                System.IO.File.WriteAllText(filePath, inodedes.Describe(node));
            });
            t.Wait();
            return t;
        }
    }
}
