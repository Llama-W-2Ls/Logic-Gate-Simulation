using System;
using LogicGates.Gates;
using LogicGates.Graphs;

namespace LogicGates
{
    class Program
    {
        static void Main()
        {
	    // Nodes necessary for creating a NAND gate
            var nodes = new Node<Gate>[]
            {
                new Node<Gate>(new InputOutputGate(false)),
                new Node<Gate>(new InputOutputGate(true)),
                new Node<Gate>(new AndGate()),
                new Node<Gate>(new NotGate()),
                new Node<Gate>(new InputOutputGate(false))
            };
            var inputs = new Node<Gate>[]
            {
                nodes[0],
                nodes[1]
            };
            var outputs = new Node<Gate>[]
            {
                nodes[4]
            };

            nodes[0].ConnectTo(nodes[2]);
            nodes[1].ConnectTo(nodes[2]);
            nodes[2].ConnectTo(nodes[3]);
            nodes[3].ConnectTo(nodes[4]);

            var graph = new Graph<Gate>(inputs, outputs);
            graph.PassSignals();

            foreach (var output in graph.Outputs)
            {
                Console.WriteLine(output.Data.IsOn);
            }
        }
    }
}
