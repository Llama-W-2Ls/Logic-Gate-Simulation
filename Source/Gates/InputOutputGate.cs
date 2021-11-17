using LogicGates.Graphs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicGates.Gates
{
    class InputOutputGate : Gate
    {
        public InputOutputGate(bool on)
        {
            IsOn = on;
        }

        public override Gate Clone()
        {
            return new InputOutputGate(IsOn);
        }

        public override void SetValue(List<Node<Gate>> inputs)
        {
            if (inputs.Count == 0)
                return;

            IsOn = inputs[0].Data.IsOn;
        }
    }
}
