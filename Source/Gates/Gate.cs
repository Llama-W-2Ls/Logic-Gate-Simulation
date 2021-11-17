using LogicGates.Graphs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicGates.Gates
{
    abstract class Gate : INode<Gate>
    {
        public bool IsOn;

        public abstract Gate Clone();

        public abstract void SetValue(List<Node<Gate>> inputs);
    }
}
