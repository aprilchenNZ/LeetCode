using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            INodeDescriber implementation = new NodeDescriber();

            var testData = new SingleChildNode("root", new TwoChildrenNode("child1",new NoChildrenNode("child3"),new SingleChildNode("child2",new NoChildrenNode("leaf1"))));
            var result = implementation.Describe(testData);
            INodeTransformer implementation2 = new NodeTransformer();
            var testData2 = new ManyChildrenNode("root",
                 new ManyChildrenNode("child1",
                     new ManyChildrenNode("leaf1"),
                     new ManyChildrenNode("child2",
                        new ManyChildrenNode("leaf2"))));
            var result2 = implementation2.Transform(testData2);
            var result3 = implementation.Describe(result2);
            Console.WriteLine(result);

            INodeWriter implementation3 = new NodeWriter(NodeDesFactory.GetNodeDescriber());
            string filepath = @"G:\WriteLines.txt";
            implementation3.WriteToFileAsync(testData, filepath);
            var result5 = File.ReadAllText(filepath);

            Console.ReadKey();
        }
    }
}
