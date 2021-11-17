using System;
using System.Collections.Generic;
using System.Text;

namespace LogicGates.Graphs
{
    public interface INode<T> where T : INode<T>
    {
        void SetValue(List<Node<T>> inputs);

        T Clone();
    }
}
