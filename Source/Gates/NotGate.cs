using LogicGates.Graphs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicGates.Gates
{
    class NotGate : Gate
    {
        public override Gate Clone()
        {
            return new NotGate();
        }

        public override void SetValue(List<Node<Gate>> inputs)
        {
            IsOn = !inputs[0].Data.IsOn;
        }
    }
}
