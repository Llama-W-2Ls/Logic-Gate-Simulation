using System;
using System.Collections.Generic;
using System.Text;

namespace LogicGates.Graphs
{
    public class Node<T> where T : INode<T>
    {
        public readonly T Data;

        public readonly List<Node<T>> Inputs;
        public readonly List<Node<T>> Outputs;

        public Node(T data)
        {
            Data = data;
            Inputs = new List<Node<T>>();
            Outputs = new List<Node<T>>();
        }

        public void ConnectTo(Node<T> to)
        {
            Outputs.Add(to);
            to.Inputs.Add(this);
        }

        public Node<T> Clone()
        {
            return new Node<T>(Data.Clone());
        }
    }
}
