using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicGates.Graphs
{
    public class Graph<T> where T : INode<T>
    {
        public readonly Node<T>[] Inputs;
        public readonly Node<T>[] Outputs;

        public Graph(Node<T>[] inputs, Node<T>[] outputs)
        {
            Inputs = inputs;
            Outputs = outputs;
        }

        void BFSearchNodes(Action<Node<T>> action)
        {
            var nodes = new Queue<Node<T>>();

            foreach (var input in Inputs)
            {
                nodes.Enqueue(input);
            }

            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();

                action.Invoke(node);

                foreach (var output in node.Outputs)
                {
                    nodes.Enqueue(output);
                }
            }
        }

        public void PassSignals()
        {
            BFSearchNodes((node) => node.Data.SetValue(node.Inputs));
        }

        public Graph<T> Clone()
        {
            // Keys: old nodes
            // Values: new nodes
            var oldToNewNodes = new Dictionary<Node<T>, Node<T>>();

            #region Re-establish connections

            BFSearchNodes((node) =>
            {
                var newNode = GetNewNode(node, oldToNewNodes);

                foreach (var input in node.Inputs)
                {
                    newNode.Inputs.Add(GetNewNode(input, oldToNewNodes));
                }

                foreach (var output in node.Outputs)
                {
                    newNode.Outputs.Add(GetNewNode(output, oldToNewNodes));
                }
            });

            #endregion

            #region Find inputs and outputs

            var inputs = new Node<T>[Inputs.Length];
            var outputs = new Node<T>[Outputs.Length];

            for (int i = 0; i < Inputs.Length; i++)
            {
                inputs[i] = oldToNewNodes[Inputs[i]];
            }

            for (int o = 0; o < Outputs.Length; o++)
            {
                outputs[o] = oldToNewNodes[Outputs[o]];
            }

            #endregion

            return new Graph<T>(inputs, outputs);
        }

        Node<T> GetNewNode(Node<T> node, Dictionary<Node<T>, Node<T>> oldToNew)
        {
            var newNode = oldToNew.ContainsKey(node)
                ? oldToNew[node]
                : node.Clone();

            return newNode;
        }
    }
}
